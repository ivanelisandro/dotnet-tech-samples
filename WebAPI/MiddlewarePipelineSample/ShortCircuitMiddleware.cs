namespace MiddlewarePipelineSample;

/// <summary>
/// Middleware for short-circuiting unauthorized access.
/// </summary>
public class ShortCircuitMiddleware
{
    public async static Task TryAccess(HttpContext context, Func<Task> next)
    {
        if (context.Request.Path == "/admin-panel")
        {
            if (!context.Response.HasStarted)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized user");
            }
            return; // Exit middleware pipeline early if unauthorized.
        }

        await next();
    }
}
