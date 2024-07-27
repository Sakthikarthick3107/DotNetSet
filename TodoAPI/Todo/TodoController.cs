using Microsoft.AspNetCore.Mvc;

namespace TodoAPI.Todo
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;
        public TodoController(ITodoRepository todoRepository) {
            this._todoRepository = todoRepository;  
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodos()
        {
            var allTodos  = await _todoRepository.GetAllTodoAsync();
            return Ok(allTodos);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetTodoById([FromRoute] int id)
        {
            var getTodoById = await _todoRepository.GetTodoByIdAsync(id);
            if (getTodoById == null)
            {
                return BadRequest();
            }
            return Ok(getTodoById);
        }

        [HttpPost]
        
        public async Task<IActionResult> CreateNewTodo([FromBody] TodoPostDTO todo)
        {
            var createNewTodo = await _todoRepository.CreateTodoAsync(todo);
            return CreatedAtAction(nameof(CreateNewTodo), createNewTodo);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateTodo([FromRoute] int id , [FromBody] TodoPutDTO todo)
        {
            var updateTodo = await _todoRepository.UpdateTodoAsync(id , todo);
            if (updateTodo == null)
            {
                return NotFound();
            }
            return Ok(updateTodo);
        }

        [HttpDelete]
        [Route("{id:int}")]
        
        public async Task<IActionResult> DeleteTodo([FromRoute] int id)
        {
            var delTodo = await _todoRepository.DeleteTodoAsync(id);
            if(delTodo == null)
            {
                return NotFound();
            }
            return Ok(delTodo);
        }
    }
}
