namespace HybridRenderingSample.Services;

/// <summary>
/// Service for mocking data retrieval.
/// </summary>
public class MockDataService
{
    /// <summary>
    /// Stores mock sample data for testing purposes.
    /// </summary>
    private readonly List<string> _data =
    [
        "Test Data 1",
        "Test Data 2",
        "Test Data 3"
    ];

    /// <summary>
    /// Retrieves the list of mocked data.
    /// Simulates long running request.
    /// </summary>
    /// <returns>The list of mocked data.</returns>
    public async Task<IReadOnlyCollection<string>> GetAll()
    {
        await Task.Delay(3000);
        return _data;
    }
}
