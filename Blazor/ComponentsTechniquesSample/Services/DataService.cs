namespace ComponentsTechniquesSample.Services;

/// <summary>
/// Class mocking a service retrieving some data for the UI.
/// </summary>
public class DataService
{
    /// <summary>
    /// Retrieves a list of items.
    /// A fixed list for demonstration purposes only.
    /// </summary>
    /// <returns>A list of items.</returns>
    public List<string> GetData()
    {
        return ["Item 1", "Item 2", "Item 3"];
    }
}
