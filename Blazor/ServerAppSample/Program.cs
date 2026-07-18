using ServerAppSample.Client;
using ServerAppSample.Components;
using ServerAppSample.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSignalR();

// Add Http Context for building URL without NavigationManager.
builder.Services.AddHttpContextAccessor();

// Add our client hub and state management.
builder.Services.AddSingleton<NotificationHubClient>();
builder.Services.AddSingleton<MessagesState>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

// Maps the SignalR hub.
app.MapHub<NotificationHub>($"/{Identifiers.NotificationHubName}");

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
