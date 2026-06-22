namespace ExplicitRouting;

/// <summary>
/// Provides routines to use with the '/search' route.
/// </summary>
public class Search
{
    /// <summary>
    /// Retrieves the content for a search. Parameters are extracted from query string.
    /// </summary>
    /// <param name="word">The word to be searched.</param>
    /// <param name="page">The current page of the search.</param>
    /// <returns></returns>
    public static Task<string> Get(string? word, int page = 1)
    {
        return Task.FromResult($"Searching '{word}' at page {page}");
    }
}
