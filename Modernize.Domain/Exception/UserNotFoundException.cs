using System.Net;

namespace Modernize.Domain
{
    /// <summary>
    /// Exception of not found user
    /// </summary>
    public class UserNotFoundException : BaseException
    {
        public UserNotFoundException(ErrorCode errorCode, HttpStatusCode httpStatusCode, string message) : base(errorCode, httpStatusCode, message)
        {
        }

        public UserNotFoundException(ErrorCode errorCode, HttpStatusCode httpStatusCode, string message, object error) : base(errorCode, httpStatusCode, message, error)
        {
        }
    }
}
