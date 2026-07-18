namespace ServerAppSample.Models;

/// <summary>
/// Represents a chat message as presented in the application.
/// </summary>
/// <param name="user">The user that sent the message.</param>
/// <param name="text">The text of the message.</param>
/// <param name="timestamp">The date and time the message was sent.</param>
public class ChatMessage(string user, string text, DateTime timestamp)
{
    public string User { get; set; } = user;
    public string Text { get; set; } = text;
    public DateTime Timestamp { get; set; } = timestamp;

    /// <summary>
    /// Gets the <see cref="Timestamp"/> in a format to be presented.
    /// </summary>
    public string TimeText => Timestamp.ToString("HH:mm");
}
