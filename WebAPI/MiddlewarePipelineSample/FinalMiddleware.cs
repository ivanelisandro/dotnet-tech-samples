namespace MiddlewarePipelineSample;

/// <summary>
/// Final middleware in the pipeline.
/// </summary>
public class FinalMiddleware
{
    public async static Task Finish(HttpContext context)
    {
        await context.Response.WriteAsync("Middleware pipeline completed\n");
    }
}
