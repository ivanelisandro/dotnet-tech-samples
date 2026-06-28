var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Users API V1"));
}

app.MapControllers();

app.Run();

// To generate new client code, uncomment the following lines. Then comment app.MapControllers and app.Run above.
// Task.Run(() => app.RunAsync());
// await new GenerateApiClientSample.ClientGenerator().Run();
