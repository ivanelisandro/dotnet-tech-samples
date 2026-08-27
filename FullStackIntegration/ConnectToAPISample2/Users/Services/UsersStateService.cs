using ConnectToAPISample2.Users.Models;

namespace ConnectToAPISample2.Users.Services;

/// <summary>
/// Represents a service that provides client state management for users information.
/// </summary>
/// <param name="usersService">The service to be used for retrieving user data.</param>
public class UsersStateService(UsersService usersService)
{
    private readonly UsersService usersService = usersService;

    public IEnumerable<User>? Users { get; private set; }

    /// <summary>
    /// Event to notify clients of changes in the current users list.
    /// </summary>
    public event Action? OnChange;

    /// <summary>
    /// Updates the current users list asynchronously.
    /// </summary>
    /// <returns>The Task containing the result of the asynchronous operation.</returns>
    public async Task UpdateAsync()
    {
        Users = await usersService.GetAll();
        NotifyStateChanged();
    }

    /// <summary>
    /// Notifies handlers of the changed state in users list.
    /// </summary>
    private void NotifyStateChanged() => OnChange?.Invoke();
}
