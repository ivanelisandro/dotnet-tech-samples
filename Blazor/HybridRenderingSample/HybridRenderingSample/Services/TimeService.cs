namespace HybridRenderingSample.Services;

/// <summary>
/// Provides access to date and time information.
/// </summary>
public class TimeService
{
    /// <summary>
    /// Retrieves the current date and time value for the server.
    /// </summary>
    /// <returns>Current date and time value.</returns>
    public DateTime GetServerTime() => DateTime.Now;
}
