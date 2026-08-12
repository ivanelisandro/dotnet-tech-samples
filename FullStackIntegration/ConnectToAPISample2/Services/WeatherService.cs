using System.Net.Http.Json;
using ConnectToAPISample2.Models;
using ConnectToAPISample2.Options;
using Microsoft.Extensions.Options;

namespace ConnectToAPISample2.Services;

/// <summary>
/// Represents a service that communicates with a weather API to retrieve information.
/// </summary>
/// <param name="client">The client to be used for connection with the API.</param>
/// <param name="options">A provider containing the options for connecting with the API.</param>
public class WeatherService(HttpClient client, IOptions<ApiOptions> options)
{
    private readonly HttpClient _client = client;
    private readonly ApiOptions _api = options.Value;

    /// <summary>
    /// Retrieves weather information for a selected city.
    /// </summary>
    /// <param name="selectedCity">The city for which to retrieve the information.</param>
    /// <returns>The weather data if a valid city is selected, null otherwise.</returns>
    public async Task<LocalWeather?> Get(AvailableCities selectedCity)
    {
        LocalWeather? weather = null;
        string city = selectedCity.DisplayName();

        try
        {
            weather = await _client.GetFromJsonAsync<LocalWeather>($"{_api.BaseAddress}&q={city}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error fetching weather data: {e.Message}");
        }

        return weather;
    }
}
