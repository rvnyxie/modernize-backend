using System.Net;
using System.Text.Json;

namespace Modernize.Domain
{
    /// <summary>
    /// Base exception defined useful properties
    /// </summary>
    public class BaseException : Exception
    {
        public ErrorCode ErrorCode { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; }

        public string? Message { get; set; }

        public object? Error { get; set; }

        public BaseException(ErrorCode errorCode, HttpStatusCode httpStatusCode, string message) : base(message)
        {
            ErrorCode = errorCode;
            HttpStatusCode = httpStatusCode;
            Message = message;
        }

        public BaseException(ErrorCode errorCode, HttpStatusCode httpStatusCode, string message, object error) : base(message)
        {
            ErrorCode = errorCode;
            HttpStatusCode = httpStatusCode;
            Message = message;
            Error = error;
        }

        public override string ToString()
        {
            var serializedException = new
            {
                ErrorCode,
                HttpStatusCode,
                Message,
                Error
            };

            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();

            // No encoding Unicode characters
            jsonSerializerOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

            // Nice format with indenting
            jsonSerializerOptions.WriteIndented = true;

            return JsonSerializer.Serialize(serializedException, jsonSerializerOptions);
        }
    }
}
