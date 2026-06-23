namespace DISample;

/// <summary>
/// Interface for log operations.
/// </summary>
public interface ILog
{
    /// <summary>
    /// Adds a message to the log output.
    /// </summary>
    /// <param name="source">An identifier for the source of the message.</param>
    /// <param name="message">The message to be added.</param>
    void Add(string source, string message);
}
