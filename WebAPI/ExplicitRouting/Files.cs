namespace ExplicitRouting;

/// <summary>
/// Provides routines to use with the '/files' route.
/// </summary>
public class Files
{
    /// <summary>
    /// Formats the value given by <paramref name="filePath"/>.
    /// </summary>
    /// <param name="filePath">A file path as extracted from the request.</param>
    /// <returns>The formatted text including the file path.</returns>
    public static Task<string> Get(string filePath)
    {
        return Task.FromResult($"Files path: {filePath}");
    }
}
