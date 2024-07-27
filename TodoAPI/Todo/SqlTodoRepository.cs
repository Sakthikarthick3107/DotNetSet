using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Data;

namespace TodoAPI.Todo
{
    public class SqlTodoRepository : ITodoRepository
     {
        private readonly TodoDbContext dbContext;
        private readonly IMapper mapper;

        public SqlTodoRepository(TodoDbContext dbContext ,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<List<TodoModel>> GetAllTodoAsync()
        {
            var getTodos = await dbContext.Todos.ToListAsync();
            return getTodos;
        }

        public async Task<TodoModel?> GetTodoByIdAsync(int id)
        {
            var getTodo = await dbContext.Todos.FirstOrDefaultAsync(todo => todo.Id == id);
            if (getTodo == null)
            {
                return null;
            }
            return getTodo;
        }

        public async Task<TodoModel> CreateTodoAsync(TodoPostDTO todo)
        {
            var newTodo = mapper.Map<TodoModel>(todo);
            await dbContext.Todos.AddAsync(newTodo);
            await dbContext.SaveChangesAsync();
            return newTodo;
        }

        public async Task<TodoModel?> UpdateTodoAsync(int id, TodoPutDTO todo)
        {
            var getTodo = await dbContext.Todos.FirstOrDefaultAsync(todo => todo.Id == id);
            if(getTodo == null)
            {
                return null;
            }
            mapper.Map(todo, getTodo);
            await dbContext.SaveChangesAsync();
            return getTodo;

        }

        public async Task<TodoModel?> DeleteTodoAsync(int id)
        {
            var getTodo = await dbContext.Todos.FirstOrDefaultAsync(todo => todo.Id == id);
            if(getTodo == null)
            {
                return null ;
            }
            dbContext.Todos.Remove(getTodo);
            await dbContext.SaveChangesAsync();
            return getTodo;
        }
    }
}
