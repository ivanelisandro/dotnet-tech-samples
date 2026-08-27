using ConnectToAPISample2;
using ConnectToAPISample2.Options;
using ConnectToAPISample2.Weather.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Sets up loading of API configuration from file.
builder.Services.Configure<ApiOptions>(
    builder.Configuration.GetSection("Api"));

// Sets up client to access the public API.
builder.Services.AddScoped(
    provider => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Sets up service to handle the weather data.
builder.Services.AddScoped<WeatherService>();
builder.Services.AddScoped<WeatherStateService>();

await builder.Build().RunAsync();
