using System.Text.Json;

using Chat.Api.Core.Responses;

namespace Chat.Api.Core.ExceptionsRequests
{
    public class InvalidModelException : ServiceException
    {
        public string[] errorMessages { get; set; }
        public override int Code { get => StatusCodes.Status400BadRequest; }
        public InvalidModelException(string[] validationErrors) : base("Ошибка валидации", "Одно или несколько полей не соответствуют правилам")
        {
            errorMessages = validationErrors;
        }
        public override string ToResponse() =>
            JsonSerializer.Serialize(new InvalidResult() { ErrorMessages = errorMessages });
    }
}
