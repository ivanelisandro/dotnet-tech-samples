using BasicSampleUI;
using BasicSampleUI.Options;
using BasicSampleUI.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Options;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Sets up loading of API configuration from file.
builder.Services.Configure<ApiOptions>(
    builder.Configuration.GetSection("Api"));

// Sets up client service that will be used to connect to the backend.
builder.Services.AddScoped(provider =>
{
    var options = provider.GetRequiredService<IOptions<ApiOptions>>().Value;

    return new HttpClient
    {
        BaseAddress = new Uri(options.BaseUrlSecure)
    };
});

// Sets up service to load products information from the backend.
builder.Services.AddScoped<ProductsService>();

await builder.Build().RunAsync();
