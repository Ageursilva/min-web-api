using Microsoft.EntityFrameworkCore;

var builder = WebAplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.build();

app.MapGet("/todoiteem", async (TodoDb db) =>
    await db.Todos.ToListAsync());

app.MapGet("/todoitem/complete", async (TodoDb db) =>
    await db.Todos.Where(t => t.IsComplete).ToListAsync());

app.MapGet("/todoitem/{id}", async (TodoDb db) =>
    await db.Todos.FindAsync(id)
        is Todo todo
            ? Results.Ok(todo)
            : Results.NotFound());
app.Run();