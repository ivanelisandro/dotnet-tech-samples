namespace ServerAppSample.Client;

/// <summary>
/// Manages the current active user of a chat.
/// </summary>
public class UserState
{
    public string UserName { get; set; }

    public bool IsUserActive { get; set; }

    /// <summary>
    /// Notifies handlers when user is activated or reset.
    /// </summary>
    public event Action? OnChange;

    /// <summary>
    /// Activates an user, setting it as the one currently in use.
    /// </summary>
    /// <param name="userName"></param>
    public void Activate(string userName)
    {
        if (string.IsNullOrEmpty(userName))
            return;

        UserName = userName;
        IsUserActive = true;
        NotifyStateChanged();
    }

    /// <summary>
    /// Resets the user state so that there is no current active user.
    /// </summary>
    public void Reset()
    {
        UserName = string.Empty;
        IsUserActive = false;
        NotifyStateChanged();
    }

    /// <summary>
    /// Raises the event to notify of user state changes.
    /// </summary>
    private void NotifyStateChanged() => OnChange?.Invoke();
}
