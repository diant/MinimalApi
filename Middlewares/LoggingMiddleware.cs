using System.Diagnostics;

internal class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        const string template = "Request {method} {url} => {statusCode} in {elapsed:0.0000} ms";

        var w = Stopwatch.StartNew();
        await _next(context);
        w.Stop();
        _logger.LogInformation(template, 
            context.Request.Method, 
            context.Request.Path, 
            context.Response.StatusCode, 
            w.ElapsedMilliseconds);
    }
}
