using System.Net;

namespace Modernize.Domain
{
    /// <summary>
    /// Exception when modificating user
    /// </summary>
    public class UserModificationException : BaseException
    {
        public UserModificationException(ErrorCode errorCode, HttpStatusCode httpStatusCode, string message) : base(errorCode, httpStatusCode, message)
        {
        }

        public UserModificationException(ErrorCode errorCode, HttpStatusCode httpStatusCode, string message, object error) : base(errorCode, httpStatusCode, message, error)
        {
        }
    }
}
