namespace ConnectToAPISample2.Weather.Models;

/// <summary>
/// Represents the current weather in a location.
/// </summary>
public class Current
{
    public required double Temp_C { get; set; }

    public required Condition Condition { get; set; }
}
