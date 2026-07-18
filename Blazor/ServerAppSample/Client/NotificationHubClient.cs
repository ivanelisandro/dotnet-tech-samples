using Microsoft.AspNetCore.SignalR.Client;
using ServerAppSample.Models;

namespace ServerAppSample.Client;

/// <summary>
/// A client that consumes notification hub messages and reports to the application.
/// </summary>
public class NotificationHubClient
{
    private bool _isStarting;
    private readonly HubConnection _hub;
    private readonly MessagesState _messagesState;

    /// <summary>
    /// Initializes a new instance of the <see cref="NotificationHubClient"/>.
    /// </summary>
    /// <param name="accessor">An HTTP context provider to allows us to build the URL for the hub.</param>
    /// <param name="messagesState">The messages state manager to be updated when we received messages.</param>
    /// <exception cref="InvalidOperationException">Throws exception if we cannot correctly build the URL
    /// from the <paramref name="accessor"/>.</exception>
    public NotificationHubClient(IHttpContextAccessor accessor, MessagesState messagesState)
    {
        _messagesState = messagesState;

        // Build URL.
        var request = (accessor.HttpContext?.Request) ?? throw new InvalidOperationException("No HTTP context available.");
        var baseUrl = $"{request.Scheme}://{request.Host}";
        var hubUrl = $"{baseUrl}/{Hubs.Identifiers.NotificationHubName}";

        // Build hub for connection.
        _hub = new HubConnectionBuilder()
            .WithUrl(hubUrl)
            .WithAutomaticReconnect()
            .Build();

        // Attach to handle when we receive messages.
        _hub.On<ChatMessage>(Hubs.Identifiers.ReceiveMethod, (message) =>
        {
            _messagesState.Add(message);
        });
    }

    /// <summary>
    /// Starts the connection with the hub asynchronously.
    /// It will temporarily transition to <see cref="HubConnectionState.Connecting"/> before
    /// establishing the hub in the <see cref="HubConnectionState.Connected"/> state.
    /// </summary>
    /// <returns>The Task representing the asychronous result.</returns>
    public async Task StartAsync()
    {
        // Avoid relaunching connection when it is in transition or already connected.
        if (_hub.State == HubConnectionState.Connected ||
            _hub.State == HubConnectionState.Connecting ||
            _hub.State == HubConnectionState.Reconnecting)
        {
            return;
        }

        // Additional prevention to concurrent calls.
        if (_isStarting)
        {
            return;
        }

        _isStarting = true;

        try
        {
            // Start the SignalR connection only once.
            await _hub.StartAsync();
        }
        finally
        {
            _isStarting = false;
        }
    }

    /// <summary>
    /// Sends the message to the hub asynchronously.
    /// </summary>
    /// <param name="userName">The username for which to build the message to send.</param>
    /// <param name="text">The text of the message to send.</param>
    /// <returns>The Task representing the asychronous result.</returns>
    public async Task SendAsync(string userName, string text)
    {
        if (_hub is null)
        {
            return;
        }

        ChatMessage message = new(userName, text, DateTime.Now);
        await _hub.SendAsync(Hubs.Identifiers.SendMethod, message);
    }
}
