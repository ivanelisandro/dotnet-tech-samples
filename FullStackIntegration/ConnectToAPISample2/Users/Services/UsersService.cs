using System.Net.Http.Json;
using ConnectToAPISample2.Users.Models;

namespace ConnectToAPISample2.Users.Services;

/// <summary>
/// Provides access to a placeholder list of users.
/// </summary>
/// <param name="client">The HTTP client required to make requests to the placeholder API.</param>
public class UsersService(HttpClient client)
{
    private const string UsersFromPlaceholder = "https://jsonplaceholder.typicode.com/users";
    private const int MinimumUsers = 1;
    private const int MaximumUsers = 10;

    private readonly HttpClient _client = client;
    private readonly Random random = new();
    private CancellationTokenSource? cancellationSource;

    /// <summary>
    /// Retrieves a placeholder list of users from placeholder API.
    /// </summary>
    /// <returns>The list of users if retrieving is successful, empty list otherwise.</returns>
    public async Task<IEnumerable<User>> GetAll()
    {
        List<User>? users = null;

        // Cancel previous request.
        cancellationSource?.Cancel(); 
        cancellationSource = new CancellationTokenSource();

        try
        {
            int randomUserCount = random.Next(MinimumUsers, MaximumUsers);
            string requestUri = $"{UsersFromPlaceholder}?_limit={randomUserCount}";

            users = await _client.GetFromJsonAsync<List<User>>(requestUri, cancellationSource.Token);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Previous user request was canceled.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Cannot retrieve users at the moment: {e.Message}");
        }

        if (users is null)
        {
            return [];
        }

        return users;
    }
}
