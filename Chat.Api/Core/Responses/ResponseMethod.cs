using Chat.Api.Core.Responses;
using Chat.Api.Domain;

using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Core.Responses
{
    public static class ResponseMethod//<T> where T : BaseResponse, new()
    {
        public static JsonResult Success(dynamic data, bool isSuccess = true, int statusCode = StatusCodes.Status200OK)
            => new(new SuccessResult() { Data = data, IsSuccess = isSuccess, StatusCode = statusCode });
        public static JsonResult Success<T>(T data, bool isSuccess = true, int statusCode = StatusCodes.Status200OK) where T : DTO
            => new(new SuccessResult() { Data = data, IsSuccess = isSuccess, StatusCode = statusCode });
        public static JsonResult Failure(string title, string message, bool isSuccess = false, int statusCode = StatusCodes.Status400BadRequest)
            => new(new BadResult() { Title = title, Message = message, IsSuccess = isSuccess, StatusCode = statusCode });
    }
}
