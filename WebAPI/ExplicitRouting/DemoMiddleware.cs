namespace ExplicitRouting;

/// <summary>
/// Class to provide execution logic for a demo middleware.
/// </summary>
public class DemoMiddleware
{
    /// <summary>
    /// Executes a demonstration logic for a middleware.
    /// </summary>
    /// <param name="context">The instance providing the current HTTP context.</param>
    /// <param name="next">The reference of the next middleware that must be executed.</param>
    /// <returns>The execution result.</returns>
    public async static Task Run(HttpContext context, RequestDelegate next)
    {
        Console.WriteLine("Logic before");
        await next.Invoke(context);
        Console.WriteLine("Logic after");
    }
}
