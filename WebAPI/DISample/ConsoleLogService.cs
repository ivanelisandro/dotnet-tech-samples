namespace DISample;

/// <summary>
/// Logs operations to <see cref="Console"/>.
/// </summary>
public class ConsoleLogService : ILog
{
    /// <summary>
    /// Formats and adds source and message to <see cref="Console"/>.
    /// </summary>
    /// <param name="source">An identifier for the source of the message.</param>
    /// <param name="message">The message to be added.</param>
    public void Add(string source, string message)
    {
        // We can use GetHashCode() as object identifier to understand when we have the same object or a different instance of the object.
        Console.WriteLine($"[Service ID: {this.GetHashCode():D8}] | {source,-12} | {message,-20} |");
    }
}
