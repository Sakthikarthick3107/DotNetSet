namespace TodoAPI.Todo
{
    public interface ITodoRepository
    {
        public Task<List<TodoModel>> GetAllTodoAsync();

        public Task<TodoModel?> GetTodoByIdAsync(int id);

        public Task<TodoModel> CreateTodoAsync(TodoPostDTO todo);

        public Task<TodoModel?> UpdateTodoAsync(int id, TodoPutDTO todo);

        public Task<TodoModel?> DeleteTodoAsync(int id);
    }
}
