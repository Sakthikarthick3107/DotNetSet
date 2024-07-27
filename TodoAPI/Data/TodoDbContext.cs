using Microsoft.EntityFrameworkCore;
using TodoAPI.Todo;

namespace TodoAPI.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }

        public DbSet<TodoModel> Todos { get; set; }
    }
}
