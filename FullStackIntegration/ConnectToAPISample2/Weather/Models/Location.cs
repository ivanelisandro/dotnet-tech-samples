namespace ConnectToAPISample2.Weather.Models;

/// <summary>
/// Represents the geographic information of the place being represented.
/// </summary>
public class Location
{
    public required string Name { get; set; }

    public required string Country { get; set; }
}
