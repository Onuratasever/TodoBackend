using Microsoft.AspNetCore.Mvc;
using TodoBackend.Domain.Entities.TodoList;
using TodoBackend.Domain.Entities.TodoItem;


namespace TodoBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoListsController: ControllerBase
{
    readonly private ITodoItemRepository _todoItemRepository;
    readonly private ITodoListRepository _todoListRepository;
    
    public TodoListsController(ITodoItemRepository todoItemRepository, ITodoListRepository todoListRepository)
    {
        _todoItemRepository = todoItemRepository;
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