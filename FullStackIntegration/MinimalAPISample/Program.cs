using MinimalAPISample.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// In-memory list to store tasks.
List<TaskItem> tasks = [];

// GET - Retrieve all tasks.
app.MapGet("/tasks", () => Results.Ok(tasks));

// POST - Add a new task.
app.MapPost("/tasks", (TaskItem task) =>
{
    tasks.Add(task);

    return Results.Created($"/tasks/{task.Id}", task);
});

// PUT - Update a task.
app.MapPut("/tasks/{id}", (int id, TaskItem updatedTask) =>
{
    var task = tasks.FirstOrDefault(t => t.Id == id);
    if (task is null)
    {
        return Results.NotFound();
    }

    task.Name = updatedTask.Name;
    task.IsCompleted = updatedTask.IsCompleted;
    return Results.Ok(task);
});

// DELETE - Remove a task.
app.MapDelete("/tasks/{id}", (int id) =>
{
    var task = tasks.FirstOrDefault(t => t.Id == id);
    if (task == null)
    {
        return Results.NotFound();
    }

    tasks.Remove(task);
    return Results.Ok(task);
});

app.Run();
