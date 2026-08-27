using ConnectToAPISample2.Weather.Models;

namespace ConnectToAPISample2.Weather.Services;

/// <summary>
/// Represents a service that provides client state management for weather information of a selected location.
/// </summary>
/// <param name="weatherService">The service to be used for retrieving weather data.</param>
public class WeatherStateService(WeatherService weatherService)
{
    private readonly WeatherService weatherService = weatherService;

    /// <summary>
    /// Gets the weather information set for a selected city.
    /// </summary>
    public LocalWeather? Weather { get; private set; }

    /// <summary>
    /// Event to notify clients of changes in the current weather state.
    /// </summary>
    public event Action? OnChange;

    /// <summary>
    /// Updates the current weather data for <paramref name="selectedCity"/> asynchronously.
    /// </summary>
    /// <param name="selectedCity">The new city to retrieve weather data.</param>
    /// <returns>The Task containing the result of the asynchronous operation.</returns>
    public async Task UpdateAsync(AvailableCities selectedCity)
    {
        Weather = await weatherService.GetAsync(selectedCity);
        NotifyStateChanged();
    }

    /// <summary>
    /// Notifies handlers of the changed state in current weather data.
    /// </summary>
    private void NotifyStateChanged() => OnChange?.Invoke();
}
