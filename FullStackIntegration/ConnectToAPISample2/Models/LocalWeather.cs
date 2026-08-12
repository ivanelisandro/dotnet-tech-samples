namespace ConnectToAPISample2.Models;

/// <summary>
/// Represents local weather information for a place in the world.
/// Information is decoded directly from a weather API.
/// </summary>
public class LocalWeather
{
    /// <summary>
    /// Gets or sets the geographic information for the weather.
    /// </summary>
    public required Location Location { get; set; }

    /// <summary>
    /// Gets or sets the current weather information for a location.
    /// </summary>
    public required Current Current { get; set; }
}
