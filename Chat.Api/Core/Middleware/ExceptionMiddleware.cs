using System.Text.Json;

using Chat.Api.Core.ExceptionsRequests;
using Chat.Api.Core.Responses;
using Chat.Database.MsSql.Context;
using Chat.Database.MsSql.Entities;

using Microsoft.AspNetCore.Http.Extensions;

namespace Chat.Api.Core.Middleware
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ChatContext _chatContext;
        private bool IsLogSaved = false;
        public ExceptionMiddleware(ChatContext chatContext)
        {
            _chatContext = chatContext;
        }

        public async Task OnActionExecution(HttpContext context, Log log)
        {
            log.IsError = false;
            log.Path = context.Request.GetDisplayUrl();
            log.Date = DateTime.Now;
            context.Request.EnableBuffering();
            log.RequestBody = await ReadBodyFromStream(context.Request.Body);
            log.IP = context.Connection.RemoteIpAddress?.ToString() ?? "Not remote";
        }

        public async Task OnActionExecuted(HttpContext context, Log log)
        {
            try
            {
                _chatContext.Logs.Add(log);
                await _chatContext.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task OnException(HttpContext context, Log log, Exception e)
        {
            log.IsError = true;
            log.ErrorMessage = e.Message;
            await SaveLog(log);
            await Send(context.Response,
                        JsonSerializer.Serialize(new BadResult()
                        {
                            IsSuccess = false,
                            Title = "Произошла ошибка на сервере",
                            Message = log.Id.ToString(),
                            StatusCode = StatusCodes.Status500InternalServerError
                        }));

        }

        public async Task OnServiceException(HttpContext context, ServiceException se, Log log)
        {
            log.IsError = false;
            await Send(context.Response, se.ToResponse(), se.Code);
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            Log log = new();
            try
            {
                await OnActionExecution(context, log);
                await next(context);
            }
            catch (ServiceException se)
            {
                await OnServiceException(context, se, log);
            }
            catch (Exception e)
            {
                await OnException(context, log, e);
                return;
            }
            finally
            {
                if (!IsLogSaved)
                    await OnActionExecuted(context, log);
            }
        }
        private async Task<string> ReadBodyFromStream(Stream request)
        {
            request.Position = 0;
            using var streamReader = new StreamReader(request, leaveOpen: true);
            var requestBody = await streamReader.ReadToEndAsync();
            request.Position = 0;
            return requestBody;
        }
        private async Task Send(HttpResponse response, string obj, int status = StatusCodes.Status500InternalServerError, string contentType = "application/json")
        {
            response.StatusCode = status;
            response.ContentType = contentType;
            await response.WriteAsync(obj);
        }
        private async Task SaveLog(Log log)
        {
            _chatContext.Logs.Add(log);
            await _chatContext.SaveChangesAsync();
            this.IsLogSaved = true;
        }
    }
}
