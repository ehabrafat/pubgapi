using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;
    private readonly IHostEnvironment _env;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IHostEnvironment env)
    {
        _logger = logger;
        _env = env;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        // 1. Log the exception with its full stack trace
        _logger.LogError(exception, "An unhandled exception has occurred: {Message}", exception.Message);

        // 2. Create a ProblemDetails object (standardized for HTTP APIs)

        // 3. Set the HTTP response status code
        httpContext.Response.StatusCode =  (int)HttpStatusCode.InternalServerError;

        // 4. Write the JSON response to the client
        await httpContext.Response.WriteAsJsonAsync(new {Error = exception.Message}, cancellationToken);

        // 5. Return true to indicate the exception was handled
        return true;
    }


  
}