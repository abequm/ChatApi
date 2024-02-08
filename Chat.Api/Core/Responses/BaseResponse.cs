using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Core.Responses
{
    public class BaseResponse
    {
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
    }
}
