using AsyncAPISample;
using AsyncAPISample.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(
    provider => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Sets up service to handle the users data.
builder.Services.AddScoped<UsersService>();

await builder.Build().RunAsync();
