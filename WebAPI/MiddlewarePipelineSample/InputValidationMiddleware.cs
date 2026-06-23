namespace MiddlewarePipelineSample;

/// <summary>
/// Middleware for input validation.
/// </summary>
public class InputValidationMiddleware
{
    public async static Task Verify(HttpContext context, Func<Task> next)
    {
        var input = context.Request.Query["search"];
        if (!IsValidInput(input))
        {
            if (!context.Response.HasStarted)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid request data");
            }
            return;
        }

        await next();
    }

    /// <summary>
    /// Validates presence of invalid values in an input text.
    /// </summary>
    /// <param name="search">A search input text that needs to be validated before usage.</param>
    /// <returns>True if the input does not contain harmful characters, false otherwise.</returns>
    private static bool IsValidInput(string? search)
    {
        // Checks for any unsafe characters or patterns.
        return string.IsNullOrEmpty(search) ||
            search.All(char.IsLetterOrDigit);
    }
}
