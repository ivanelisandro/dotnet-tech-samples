namespace MiddlewarePipelineSample;

/// <summary>
/// Middleware for simulating authentication and secure cookies.
/// </summary>
public class AuthenticationSimulationMiddleware
{
    public async static Task Verify(HttpContext context, Func<Task> next)
    {
        // Mocks an authentication verification using query string parameter.
        // Not an realistic implementation though. Just used to demonstrate the middleware pipeline.
        var isLoggedOn = context.Request.Query["userlogged"] == "true";
        if (!isLoggedOn)
        {
            if (!context.Response.HasStarted)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("User not logged on");
            }
            return;
        }

        context.Response.Cookies.Append(
            "SecureCookie",
            "SecureData",
            new CookieOptions
            {
                HttpOnly = true,
                Secure = true
            });

        await next();
    }
}
