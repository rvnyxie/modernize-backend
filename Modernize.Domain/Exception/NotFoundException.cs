using System.Net;

namespace Modernize.Domain
{
    /// <summary>
    /// Execption when not found
    /// </summary>
    public class NotFoundException : BaseException
    {
        public NotFoundException(ErrorCode errorCode, HttpStatusCode httpStatusCode, string message) : base(errorCode, httpStatusCode, message)
        {
        }

        public NotFoundException(ErrorCode errorCode, HttpStatusCode httpStatusCode, string message, object error) : base(errorCode, httpStatusCode, message, error)
        {
        }
    }
}
