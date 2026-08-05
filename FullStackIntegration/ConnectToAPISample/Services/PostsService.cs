using System.Net.Http.Json;

namespace ConnectToAPISample.Services;

/// <summary>
/// Provides access to a placeholder list of posts.
/// </summary>
/// <param name="client">The HTTP client required to make requests to the external API.</param>
public class PostsService(HttpClient client)
{
    private const string PostsFromPlaceholder = "https://jsonplaceholder.typicode.com/posts";
    private readonly HttpClient _client = client;

    /// <summary>
    /// Retrieves a placeholder list of posts from an external API.
    /// </summary>
    /// <returns>The list of posts if retrieving is successful, empty list otherwise.</returns>
    public async Task<IEnumerable<Post>> GetAll()
    {
        List<Post>? posts = null;

        try
        {
            posts = await _client.GetFromJsonAsync<List<Post>>(PostsFromPlaceholder);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Cannot retrieve posts at the moment: {e.Message}");
        }

        if (posts is null)
        {
            return [];
        }

        return posts;
    }
}

/// <summary>
/// Represents a post as retrieved from the external API.
/// </summary>
/// <param name="Id">The unique identifier of the post.</param>
/// <param name="Title">The title of the post.</param>
/// <param name="Body">The body of the post.</param>
public record Post(int Id, string Title, string Body);
