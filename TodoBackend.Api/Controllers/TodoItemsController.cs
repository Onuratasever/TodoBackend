using Microsoft.AspNetCore.Mvc;
using TodoBackend.Domain.Entities.TodoList;
using TodoBackend.Domain.Entities.TodoItem;

namespace TodoBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoItemsController: ControllerBase
{
    readonly private ITodoItemRepository _todoItemRepository;
    readonly private ITodoListRepository _todoListRepository;
    
    public TodoItemsController(ITodoItemRepository todoItemRepository, ITodoListRepository todoListRepository)
    {
        _todoItemRepository = todoItemRepository;
        _todoListRepository = todoListRepository;
    }
    
    [HttpGet("{userId:guid}/{id:guid}/items")]
    public async Task<IActionResult> GetTodoItems(Guid userId, Guid id)
    {
        var todoList = await _todoListRepository.GetByIdAsync(id);
        if(todoList == null)
        {
            return NotFound("TodoList not found");
        }
        if(todoList.UserId != userId)
        {
            return Unauthorized();
        }
        var todoItems = await _todoItemRepository.GetListAsync(todoListId => todoListId.TodoListId == id);
        return Ok(todoItems);
    }
    
    [HttpPost("{userId:guid}/{id:guid}/items")]
    public async Task<IActionResult> CreateTodoItem(Guid userId, Guid id, TodoItem todoItem)
    {
        var todoList = await _todoListRepository.GetByIdAsync(id);
        if(todoList == null)
        {
            return NotFound("TodoList not found");
        }
        if(todoList.UserId != userId)
        {
            return Unauthorized();
        }
        
        todoItem.Id = Guid.NewGuid();
        todoItem.TodoListId = id;
        todoItem.CreatedAt = DateTime.Now;
        todoItem.UpdatedAt = DateTime.Now;
        
        _todoItemRepository.Add(todoItem);
        
        await _todoItemRepository.SaveChangesAsync();
        return Ok(todoItem);
    }
    
    [HttpPut("{userId:guid}/{id:guid}/items/{itemId:guid}")]
    public async Task<IActionResult> UpdateTodoItem(Guid userId, Guid id, Guid itemId, TodoItem todoItem)
    {
        var todoList = await _todoListRepository.GetByIdAsync(id);
        if(todoList == null)
        {
            return NotFound("TodoList not found");
        }
        if(todoList.UserId != userId)
        {
            return Unauthorized();
        }
        var existingTodoItem = await _todoItemRepository.GetByIdAsync(itemId);
        if(existingTodoItem == null)
        {
            return NotFound("TodoItem not found");
        }

        if (existingTodoItem.TodoListId != id)
        {
            return NotFound("TodoItem not found");
        }
        existingTodoItem.Title = todoItem.Title;
        existingTodoItem.Description = todoItem.Description;
        existingTodoItem.UpdatedAt = DateTime.Now;
        existingTodoItem.Status = todoItem.Status;
        existingTodoItem.Priority = todoItem.Priority;
        existingTodoItem.DueDate = todoItem.DueDate;
        
        _todoItemRepository.Update(existingTodoItem);
        
        await _todoItemRepository.SaveChangesAsync();
        return Ok(existingTodoItem);
    }
    
    [HttpDelete("{userId:guid}/{id:guid}/items/{itemId:guid}")]
    public async Task<IActionResult> DeleteTodoItem(Guid userId, Guid id, Guid itemId) 
    {
        var todoList = await _todoListRepository.GetByIdAsync(id);
        if(todoList == null)
        {
            return NotFound("TodoList not found");
        }
        if(todoList.UserId != userId)
        {
            return Unauthorized();
        }
        var existingTodoItem = await _todoItemRepository.GetByIdAsync(itemId);
        if(existingTodoItem == null)
        {
            return NotFound("TodoItem not found");
        }
        
        if(existingTodoItem.TodoListId != id)
        {
            return BadRequest("TodoItem does not belong to the TodoList");
        }
        _todoItemRepository.Delete(existingTodoItem);
        
        await _todoItemRepository.SaveChangesAsync();
        return Ok();
    }
}