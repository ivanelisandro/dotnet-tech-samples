using Microsoft.AspNetCore.SignalR;
using ServerAppSample.Models;

namespace ServerAppSample.Hubs;

/// <summary>
/// Provides routines for communication through a SignalR hub.
/// </summary>
public class NotificationHub : Hub
{
    /// <summary>
    /// Sends a <paramref name="message"/> to all hub clients.
    /// </summary>
    /// <param name="message">The message to be reported.</param>
    /// <returns>The Task representing the asychronous result.</returns>
    public async Task SendMessage(ChatMessage message)
    {
        await Clients.All.SendAsync(Identifiers.ReceiveMethod, message);
    }
}
