using ExplicitRouting;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging((o) => { });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(DemoMiddleware.Run); // Middleware demo

app.UseHttpsRedirection();
app.UseHttpLogging(); // Logging middleware

app.MapGet("/", Home.Get);

// Users routes
app.MapGet("/users", Users.GetAll);

app.MapGet("/users/{id:int:min(0)}", Users.Get); // Route with parameters and route constraints.
app.MapPost("/users", Users.Post);

app.MapPut("/users/{id:int:min(0)}", Users.Put); // Route with parameters and route constraints.
app.MapDelete("/users/{id:int:min(0)}", Users.Delete); // Route with parameters and route constraints.

// Other routes
app.MapGet("/reports/{year?}", Reports.Get); // Route parameter modifier. Optional parameter 'year'.

app.MapGet("/files/{*filePath}", Files.Get); // Catch-all route parameter.

app.MapGet("/search", Search.Get); // Automatic query string binding.

app.Run();
