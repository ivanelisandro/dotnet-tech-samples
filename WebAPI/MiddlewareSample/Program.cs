var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// HTTP logging to capture request and response details.
builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
    options.RequestBodyLogLimit = 4096;
    options.ResponseBodyLogLimit = 4096;
});

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();


// Applying logging, authentication and authorization middleware.
app.UseHttpLogging();
app.UseAuthentication();
app.UseAuthorization();

// Middleware to calculate execution time.
app.Use(async (context, next) =>
{
    var startTime = DateTime.UtcNow;
    Console.WriteLine($"Start Time: {startTime}");
    await next();
    var duration = DateTime.UtcNow - startTime;
    Console.WriteLine($"Response Time: {duration.TotalMilliseconds} ms");
});

// Middleware to log simple message.
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request Path: {context.Request.Path}");
    await next();
    Console.WriteLine($"Response Status Code: {context.Response.StatusCode}");
});

app.MapGet("/", () => "Hello, ASP.NET Core Middleware!");

app.Run();
