using ServerAppSample.Models;

namespace ServerAppSample.Client;

/// <summary>
/// Manages state of a collection of messages presented to the user.
/// </summary>
public class MessagesState
{
    /// <summary>
    /// Notifies handlers when the collection of messages is changed.
    /// </summary>
    public event Action? OnChange;

    public List<ChatMessage> All { get; } = [];

    /// <summary>
    /// Adds a message to the chat presentation.
    /// </summary>
    /// <param name="message">The message to add.</param>
    public void Add(ChatMessage message)
    {
        All.Add(message);
        OnChange?.Invoke();
    }
}
