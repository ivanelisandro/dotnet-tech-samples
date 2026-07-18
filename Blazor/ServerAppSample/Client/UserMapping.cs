namespace ServerAppSample.Client;

/// <summary>
/// Maps user relation to the current state.
/// Provides routines to determine if the user is the owner of a message or not.
/// Maps users to indexes so they can be presented differently.
/// </summary>
/// <param name="userState">The state representing the current active user of a chat.</param>
public class UserMapping(UserState userState)
{
    private readonly UserState _userState = userState;
    private readonly IndexMapping indexMapping = new();

    /// <summary>
    /// Verifies if a given username represents the current active user.
    /// </summary>
    /// <param name="userName">The username to compare to <see cref="UserState"/>.</param>
    /// <returns>True if the username matches, false otherwise.</returns>
    public bool IsMe(string userName)
    {
        return userName.Equals(_userState.UserName, StringComparison.CurrentCulture);
    }

    /// <summary>
    /// Gets an index representing the sender of a message.
    /// Up to 12 different senders can be represented (0 to 11).
    /// </summary>
    /// <param name="sender">The username of a message.</param>
    /// <returns>A stable index representing the sender.</returns>
    public int GetSenderIndex(string sender)
    {
        return indexMapping.Get(sender);
    }

    /// <summary>
    /// Maps users to stable indexes (0 to 11).
    /// </summary>
    private class IndexMapping
    {
        private readonly Dictionary<string, int> senders = [];
        private int nextSenderIndex = 0;

        /// <summary>
        /// Retrieves the value of the mapped index for a given username.
        /// </summary>
        /// <param name="sender">The username to retrieve the index.</param>
        /// <returns>A stable index representing the sender.</returns>
        internal int Get(string sender)
        {
            if (!senders.ContainsKey(sender))
            {
                senders[sender] = nextSenderIndex % 12;
                nextSenderIndex++;
            }

            return senders[sender];
        }
    }
}
