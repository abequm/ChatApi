using System.Reflection;

namespace Chat.Api.Core.Responses
{
    public class BadResult : BaseResponse
    {
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
