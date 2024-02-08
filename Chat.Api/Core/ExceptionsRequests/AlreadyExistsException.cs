namespace Chat.Api.Core.ExceptionsRequests
{
    public class AlreadyExistsException : ServiceException
    {
        public override int Code { get => StatusCodes.Status409Conflict; }
        public AlreadyExistsException(string? title = null, string? message = null) : base(title, message)
        {

        }
    }
}
