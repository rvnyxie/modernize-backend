using Modernize.Domain;
using System.Net;

namespace Modernize.API
{
    /// <summary>
    /// Middleware to handle exceptions
    /// </summary>
    public class ExceptionMiddleware
    {
        #region Decalaration

        private readonly RequestDelegate _next;

        #endregion

        #region Constructor

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        #endregion

        #region Methods

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Catch and hanle exceptions
        /// </summary>
        /// <param name="context">Http context</param>
        /// <param name="exception">Exception catched</param>
        /// <returns></returns>
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            Console.WriteLine(exception);
            context.Response.ContentType = "application/json";

            switch (exception)
            {
                case InvalidCredentialException invalidCredentialException:
                    //context.Response.StatusCode = (int)invalidCredentialException.HttpStatusCode;
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync(
                        text: exception.ToString()
                    );
                    break;
                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsync(
                        text: new BaseException
                        (
                            ErrorCode.UNHANDLED,
                            HttpStatusCode.InternalServerError,
                            exception.Message
                        ).ToString()
                    );
                    break;
            }
        }

        #endregion
    }
}
