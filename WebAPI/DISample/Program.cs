using DISample;

var builder = WebApplication.CreateBuilder(args);

// Analyzing services with different lifetimes.
// Use only one at a time: Singleton OR Scoped OR Transient.
// The unused ones should be commented.

// Singleton service: only one instance will exist for the whole application.
// builder.Services.AddSingleton<ILog, ConsoleLogService>();

// Scoped service: an instance will be created and shared over a request processing. A different request will create a separate instance.
// builder.Services.AddScoped<ILog, ConsoleLogService>();

// Transient service: each operation using the service will use a separate instance.
builder.Services.AddTransient<ILog, ConsoleLogService>();

var app = builder.Build();

const string Start = "Execution started";
const string Finish = "Execution finished";

// Middlewares to demonstrate lifecycle in multiple parts of the pipeline.
app.Use(async (context, next) =>
{
    const string identifier = "Middleware 1";
    var logService = context.RequestServices.GetRequiredService<ILog>();
    logService.Add(identifier, Start);
    await next();

    logService.Add(identifier, Finish);
});

app.Use(async (context, next) =>
{
    const string identifier = "Middleware 2";
    var logService = context.RequestServices.GetRequiredService<ILog>();
    logService.Add(identifier, Start);
    await next();

    logService.Add(identifier, Finish);
});

// Final endpoint to demonstrate service lifecycle in the request.
app.MapGet("/", (ILog logService) =>
{
    logService.Add("Home Route", "'/' endpoint reached");
    return Results.Ok("Verify logs added to console.");
});

app.Run();
