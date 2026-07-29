namespace BasicSampleUI.Options;

/// <summary>
/// Provides information about the backend API loaded from configuration file.
/// </summary>
public class ApiOptions
{
    public string BaseUrl { get; set; } = string.Empty;

    public string BaseUrlSecure { get; set; } = string.Empty;

    public EndpointsOptions Endpoints { get; set; } = new();
}
