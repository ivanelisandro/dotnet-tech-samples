namespace MiddlewarePipelineSample;

/// <summary>
/// Mocked HTTPS-only requirement middleware.
/// </summary>
public class SecurityEnforcementMiddleware
{
    public async static Task Execute(HttpContext context, Func<Task> next)
    {
        // Checks for a query parameter to mock HTTPS-only requirement.
        // Not an realistic implementation though. Just used to demonstrate the middleware pipeline.
        if (context.Request.Query["protected"] != "true")
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("HTTPS-only mocked");
            return;
        }

        await next();
    }
}
