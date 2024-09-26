using Microsoft.AspNetCore.Mvc;
using TodoBackend.Domain.Entities.TodoList;

namespace TodoBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoListsController: ControllerBase
{
    readonly private ITodoListRepository _todoListRepository;
    
    public TodoListsController(ITodoListRepository todoListRepository)
    {
        _todoListRepository = todoListRepository;
    }
    
    [HttpGet("{userId:guid}/getAllTodoLists")]
    public async Task<IActionResult> GetUserById(Guid userId)
    {
        var todoLists = await _todoListRepository.GetListAsync(user => user.UserId == userId);
        return Ok(todoLists);
    }
    
    [HttpGet("{userId:guid}/{id:guid}")]
    public async Task<IActionResult> GetTodoListById(Guid userId,Guid id)
    {
        var todoList = await _todoListRepository.GetByIdAsync(id);
        if (todoList == null)
        {
            return NotFound();
        }
        
        if (userId != todoList.UserId)
        {
            return Unauthorized();    
        }
        return Ok(todoList);
    }
    
    [HttpPost("{userId:guid}/createTodoList")]
    public async Task<IActionResult> CreateTodoList(Guid userId,TodoList todoList)
    {
        todoList.Id = Guid.NewGuid();
        todoList.CreatedAt = DateTime.Now;
        todoList.UpdatedAt = DateTime.Now;
        todoList.UserId = userId;
        
        _todoListRepository.Add(todoList);
        
        await _todoListRepository.SaveChangesAsync();
        return Ok(todoList);
    }
    
    [HttpPut("{userId:guid}/updateTodoList/{id:guid}")]
    public async Task<IActionResult> UpdateTodoList(Guid userId, Guid id, TodoList todoList)
    {
        var existingTodoList = await _todoListRepository.GetByIdAsync(id);
        if(existingTodoList == null)
        {
            return NotFound("TodoList not found");
        }

        if (existingTodoList.UserId != userId)
        {
            return Unauthorized();
        }
        existingTodoList.Title = todoList.Title;
        existingTodoList.UpdatedAt = DateTime.Now;
        
        _todoListRepository.Update(existingTodoList);
        
        await _todoListRepository.SaveChangesAsync();
        return Ok(existingTodoList);
    }
    
    [HttpDelete("{userId:guid}/deleteTodoList/{id:guid}")]
    public async Task<IActionResult> DeleteTodoList(Guid userId,Guid id)
    {
        var existingTodoList = await _todoListRepository.GetByIdAsync(id);
        if(existingTodoList == null)
        {
            return NotFound("TodoList not found");
        }

        if (existingTodoList.UserId != userId)
        {
            return Unauthorized();
        }
        
        _todoListRepository.Delete(existingTodoList);
        
        await _todoListRepository.SaveChangesAsync();
        return Ok();
    }
}