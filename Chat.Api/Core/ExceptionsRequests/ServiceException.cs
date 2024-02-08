using System.Reflection;
using System.Text.Json;

using Chat.Api.Core.Responses;

using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Core.ExceptionsRequests
{
    public class ServiceException : SystemException, IResponsableException
    {
        /// <summary>
        /// По умолчанию 
        /// <para>
        /// <c>
        /// Произошла ошибка
        /// </c>
        /// </para>
        /// </summary>
        public virtual string Title { get; set; } = "Произошла ошибка";
        /// <summary>
        /// По умолчанию
        /// <para>
        /// <c>
        /// Произошла непредвиденная ошибка на сервере
        /// </c>
        /// </para>
        /// </summary>
        public new virtual string Message { get; set; } = "Произошла непредвиденная ошибка на сервере";
        /// <summary>
        /// По умолчанию
        /// <para>
        /// <c>
        /// 500 <see cref="StatusCodes.Status500InternalServerError"/>
        /// </c>
        /// </para>
        /// </summary>
        public virtual int Code { get; set; } = StatusCodes.Status500InternalServerError;
        /// <summary>
        /// Класс ошибок для их корректных ответов
        /// </summary>
        /// <param name="title">
        /// По умолчанию 
        /// <para>
        /// <c>
        /// Произошла ошибка
        /// </c>
        /// </para></param>
        /// <param name="message">
        /// По умолчанию
        /// <para>
        /// <c>
        /// Произошла непредвиденная ошибка на сервере
        /// </c>
        /// </para></param>
        /// <param name="code">
        /// По умолчанию
        /// <para>
        /// <c>
        /// 500 <see cref="StatusCodes.Status500InternalServerError"/>
        /// </c>
        /// </para>
        /// </param>
        public ServiceException(string? title = null, string? message = null, int? code = null)
        {
            if (title is not null) this.Title = title;
            if (message is not null) this.Message = message;
            if (code is not null) this.Code = (int)code;
        }
        public virtual string ToResponse() =>
            JsonSerializer.Serialize(new BadResult() { StatusCode = this.Code, Title = this.Title, Message = this.Message });
    }
}
