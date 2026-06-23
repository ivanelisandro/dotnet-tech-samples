namespace MiddlewarePipelineSample;

/// <summary>
/// Middleware to log security events if response status indicates an issue.
/// </summary>
public class SecurityLogMiddleware
{
    public async static Task Log(HttpContext context, Func<Task> next)
    {
        await next(); // Runs the next middleware first.

        if (context.Response.StatusCode >= 400)
        {
            string path = context.Request.Path;
            int code = context.Response.StatusCode;
            string message = $"[Security] Route: {path} | Status: {code} |";
            Console.WriteLine(message);
        }
    }
}
