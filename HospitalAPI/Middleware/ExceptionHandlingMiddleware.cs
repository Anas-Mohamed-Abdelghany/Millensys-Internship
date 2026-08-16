using System.Net;
using System.Text.Json;
using HospitalAPI.Shared;

namespace HospitalAPI.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var (statusCode, message) = exception switch
            {
                ArgumentException ex => (HttpStatusCode.BadRequest, ex.Message),
                KeyNotFoundException ex => (HttpStatusCode.NotFound, ex.Message),
                UnauthorizedAccessException ex => (HttpStatusCode.Unauthorized, "Unauthorized access"),
                InvalidOperationException ex => (HttpStatusCode.Conflict, ex.Message),
                _ => (HttpStatusCode.InternalServerError, "An internal server error occurred")
            };

            context.Response.StatusCode = (int)statusCode;

            var response = ApiResponse<object>.ErrorResponse(message, new List<string> { exception.Message });
            var json = JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            await context.Response.WriteAsync(json);
        }
    }
}
