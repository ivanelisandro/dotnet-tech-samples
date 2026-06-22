namespace ExplicitRouting;

/// <summary>
/// Provides routines to use with the '/' route.
/// </summary>
public class Home
{
    /// <summary>
    /// Retrieves a text to be shown when the home is requested.
    /// </summary>
    /// <returns>The home page text.</returns>
    public static string Get()
    {
        return "Home page!";
    }
}
