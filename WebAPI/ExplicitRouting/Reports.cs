namespace ExplicitRouting;

/// <summary>
/// Provides routines to use with the '/reports' route.
/// </summary>
public class Reports
{
    /// <summary>
    /// Retrieves the content from the reports.
    /// </summary>
    /// <param name="year">The year for which to retrieve the reports.</param>
    /// <returns>Content for reports for given year.</returns>
    public static Task<string> Get(int? year = 2014)
    {
        return Task.FromResult($"Report from {year}");
    }
}
