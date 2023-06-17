using System;
namespace DriverManagementSystemAPI.Utilities
{
    public class CustomException : Exception
    {
        public int ErrorCode { get; private set; }
        public int HttpStatusCode { get; private set; }

        public CustomException(int errorCode, int httpStatusCode, string errorMessage)
            : base(errorMessage)
        {
            ErrorCode = errorCode;
            HttpStatusCode = httpStatusCode;
        }

        public object ToJsonResponse()
        {
            return new
            {
                error = new
                {
                    ErrorCode,
                    HttpStatusCode,
                    Message
                }
            };
        }
    }
}