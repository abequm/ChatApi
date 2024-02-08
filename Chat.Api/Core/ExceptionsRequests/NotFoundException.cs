namespace Chat.Api.Core.ExceptionsRequests
{
    public class NotFoundException : ServiceException
    {
        /// <summary>
        /// <see cref="StatusCodes.Status404NotFound"/>
        /// </summary>
        public override int Code { get => StatusCodes.Status404NotFound; }
        public NotFoundException(string? title = null, string? message = null) : base(title, message)
        {

        }
    }
}
