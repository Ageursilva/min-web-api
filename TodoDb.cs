using Microsoft.EntityFrameworkCore;
class TodoDb: DbContext
{
    public TodoDb(DbContextOptions<TodoDb>)
    : base(options) { }
    public DbSet<Todo> Todos => Set<Todo>();
}