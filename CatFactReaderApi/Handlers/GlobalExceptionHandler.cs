using CatFactReaderApi.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CatFactReaderApi.Handlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        private readonly IHostEnvironment _host;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IHostEnvironment host)
        {
            _logger = logger;
            _host = host;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "An unhandled exception occurred.");
            string title;
            int status;
            string detail;

            switch (exception)
            {
                case ExternalApiEmptyResponseException:
                    status = StatusCodes.Status502BadGateway;
                    title = "External service problem";
                    detail = exception.Message;
                    break;
                default:
                    status = StatusCodes.Status500InternalServerError;
                    title = "Internal sertver error";
                    detail = "An unexpected error occurred. Please try again later.";
                    break;
            }

            var problemDetails = new ProblemDetails()
            {
                Status = status,
                Title = title,
                Detail = _host.IsEnvironment("Development") ? exception.ToString() : detail,
            };

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
            return true;
        }
    }
}
