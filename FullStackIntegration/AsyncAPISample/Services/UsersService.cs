using System.Net.Http.Json;

namespace AsyncAPISample.Services;

/// <summary>
/// Provides access to a placeholder list of users.
/// </summary>
/// <param name="client">The HTTP client required to make requests to the placeholder API.</param>
public class UsersService(HttpClient client)
{
    private const string UsersFromPlaceholder = "https://jsonplaceholder.typicode.com/users";

    private readonly HttpClient _client = client;
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
            users = await _client.GetFromJsonAsync<List<User>>(UsersFromPlaceholder, cancellationSource.Token);
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

/// <summary>
/// Represents user data.
/// </summary>
/// <param name="Id">The unique identifier of the user.</param>
/// <param name="Name">The name of the user.</param>
/// <param name="Email">The email of the user.</param>
/// <param name="Address">The address data for the user.</param>
public record User(int Id, string Name, string Email, Address Address);


/// <summary>
/// Represents address of an user.
/// </summary>
/// <param name="Street">The street for the address.</param>
/// <param name="Suite">The suite for the address.</param>
/// <param name="City">The city name for the address.</param>
/// <param name="Zipcode">The ZIP code for the address.</param>
public record Address(string Street, string Suite, string City, string Zipcode);
