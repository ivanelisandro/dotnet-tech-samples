namespace ConnectToAPISample2.Weather.Models;

/// <summary>
/// Represents the overall conditions of the weather.
/// </summary>
public class Condition
{
    public required string Text { get; set; }

    public required string Icon { get; set; }
}
