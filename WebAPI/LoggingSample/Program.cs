using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure logging (optional).
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Configure Serilog.
string logFilePath = Path.Combine(AppContext.BaseDirectory, "logs", "execution-log-.log");
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure middleware for error handling.
app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception e)
    {
        Console.WriteLine($"Unhandled exception: {e.Message}");
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("An unexpected error occurred. Please try again later.");
    }
});

app.MapControllers();

app.Run();
