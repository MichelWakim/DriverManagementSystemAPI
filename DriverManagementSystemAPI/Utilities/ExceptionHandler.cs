using System;
using Microsoft.AspNetCore.Mvc;

namespace DriverManagementSystemAPI.Utilities
{
    public static class ExceptionHandler
    {
        public static IActionResult HandleException(Exception ex)
        {
            if (ex is CustomException customEx)
            {
                return new ObjectResult(customEx.ToJsonResponse())
                {
                    StatusCode = customEx.HttpStatusCode
                };
            }
            else
            {
                return new ObjectResult(new { error = ex.Message })
                {
                    StatusCode = 500
                };
            }
        }
    }

}

