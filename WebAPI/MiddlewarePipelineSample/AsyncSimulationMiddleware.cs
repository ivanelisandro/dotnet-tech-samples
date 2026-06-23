namespace MiddlewarePipelineSample;

/// <summary>
/// Middleware for simulating asynchronous task processing.
/// </summary>
public class AsyncSimulationMiddleware
{
    public async static Task Execute(HttpContext context, Func<Task> next)
    {
        await Task.Delay(100); // Simulating long task running asynchronously.

        await context.Response.WriteAsync("Asynchronous task completed\n");

        await next();
    }
}
