using System.Net.Http.Json;
using BasicSampleUI.Options;
using Microsoft.Extensions.Options;

namespace BasicSampleUI.Services;

/// <summary>
/// Provides access to products information from the backend API.
/// </summary>
/// <param name="client">The client used to access the backend API.</param>
/// <param name="options">The API configuration containing endpoints information.</param>
public class ProductsService(HttpClient client, IOptions<ApiOptions> options)
{
    private readonly HttpClient _client = client;
    private readonly ApiOptions _api = options.Value;

    /// <summary>
    /// Retrieves the list of products from the backend asynchronously.
    /// </summary>
    /// <returns>A list of products if found, empty list otherwise.</returns>
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var products = await _client.GetFromJsonAsync<IEnumerable<Product>>(
            _api.Endpoints.Products) ?? [];

        return products;
    }
}

/// <summary>
/// Represents a product retrieved from the backend API.
/// </summary>
/// <param name="Id">The unique identifier of the product.</param>
/// <param name="Name">The name of the product.</param>
public record Product(int Id, string Name);
