﻿using System.Net;

namespace Modernize.Domain
{
    /// <summary>
    /// Exception for invalid credentials
    /// </summary>
    public class InvalidCredentialException : BaseException
    {
        public InvalidCredentialException(ErrorCode errorCode, HttpStatusCode httpStatusCode, string message) : base(errorCode, httpStatusCode, message)
        {
        }

        public InvalidCredentialException(ErrorCode errorCode, HttpStatusCode httpStatusCode, string message, object error) : base(errorCode, httpStatusCode, message, error)
        {
        }
    }
}
