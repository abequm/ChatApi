using Chat.Api.Core.Responses;

namespace Chat.Api.Core.Responses
{
    public class InvalidResult : BaseResponse
    {
        public string[] ErrorMessages { get; set; } 
    }
}
