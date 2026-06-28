namespace GenerateApiClientConsumer;

/// <summary>
/// Provides routines to validate API client.
/// </summary>
/// <param name="apiClient">The auto-generated API client.</param>
internal class UsersValidation(UsersApiClient apiClient)
{
    private readonly UsersApiClient _apiClient = apiClient;

    /// <summary>
    /// Reads all users from the API client and prints in a table-like style.
    /// </summary>
    /// <returns>The result of the asynchronous operation.</returns>
    internal async Task ReadAll()
    {
        Console.WriteLine(Formatting.Separator);
        
        var allUsers = await _apiClient.UserAllAsync();

        foreach (var user in allUsers)
        {
            Console.WriteLine(Formatting.AsTableRow(user));
        }

        Console.WriteLine(Formatting.Separator);
    }

    /// <summary>
    /// Reads a single user by ID and prints it to the console.
    /// </summary>
    /// <param name="id">The ID of an user.</param>
    /// <returns>The result of the asynchronous operation.</returns>
    internal async Task ReadSingle(int id)
    {
        var user = await _apiClient.UserGETAsync(id);
        Console.WriteLine($"Retrieved User: {Formatting.WithFieldNames(user)}");
    }

    /// <summary>
    /// Adds an user with the given <paramref name="userName"/> and displays the result.
    /// </summary>
    /// <param name="userName">The name of the user to add.</param>
    /// <returns>The result of the asynchronous operation.</returns>
    internal async Task Add(string userName)
    {
        UserDto newUser = new() { Name = userName };
        var user = await _apiClient.UserPOSTAsync(newUser);

        Console.WriteLine($"Added User: {Formatting.WithFieldNames(user)}");
    }

    /// <summary>
    /// Updates an user by a given <paramref name="id"/>.
    /// </summary>
    /// <param name="id">The ID of an user.</param>
    /// <param name="newName">The name of the user to update.</param>
    /// <returns>The result of the asynchronous operation.</returns>
    internal async Task Update(int id, string newName)
    {
        UserDto updateUser = new() { Name = newName };
        var user = await _apiClient.UserPUTAsync(id, updateUser);

        Console.WriteLine($"Updated User: {Formatting.WithFieldNames(user)}");
    }

    /// <summary>
    /// Removes an user by a given <paramref name="id"/>.
    /// </summary>
    /// <param name="id">The ID of an user.</param>
    /// <returns>The result of the asynchronous operation.</returns>
    internal async Task Remove(int id)
    {
        await _apiClient.UserDELETEAsync(id);
        Console.WriteLine($"Removed User ID: {id}");
    }

    /// <summary>
    /// Provides methods for formatting user information.
    /// </summary>
    private class Formatting
    {
        private const int NameCellSize = 20;
        internal static readonly string Separator = new('-', 29);

        /// <summary>
        /// Formats the user information to look like a row in a table.
        /// </summary>
        /// <param name="user">The user to format.</param>
        /// <returns>A string looking like a table row based on the user information.</returns>
        internal static string AsTableRow(User? user)
        {
            return user is null ? "Not found" : $"| {user.Id:D2} | {user.Name,-NameCellSize} |";
        }

        /// <summary>
        /// Formats the user information with fields names.
        /// </summary>
        /// <param name="user">The user to format.</param>
        /// <returns>A formatted string based on the user information.</returns>
        internal static string WithFieldNames(User? user)
        {
            return user is null ? "Not found" : $"ID: {user.Id} - Name: {user.Name}";
        }
    }
}
