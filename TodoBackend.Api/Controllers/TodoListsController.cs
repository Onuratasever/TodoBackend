using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoBackend.Application.TodoLists.GetByTodoListId;
using TodoBackend.Application.TodoLists.GetByUserId;
using TodoBackend.Application.TodoLists.Update;
using TodoBackend.Domain.Entities.TodoList;

namespace TodoBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoListsController: ControllerBase
{
    readonly private ITodoListRepository _todoListRepository;
    readonly private IMediator _mediator;
    public TodoListsController(ITodoListRepository todoListRepository, IMediator mediator)
    {
        _todoListRepository = todoListRepository;
        _mediator = mediator;
    }
    
    [HttpGet("{userId:guid}/getAllTodoLists")]
    public async Task<IActionResult> GetByUserId(Guid userId)
    {
        var request = new GetByUserIdQueryRequest {Id = userId};
        var response = await _mediator.Send(request);
        return Ok(response);
    }
    
    [HttpGet("{userId:guid}/{id:guid}")]
    public async Task<IActionResult> GetTodoListById(Guid userId,Guid id)
    {
        var request = new GetByTodoListIdQueryRequest {TodoListId = id, UserId = userId};
        
        var response = await _mediator.Send(request);
        
        if (!response.Success && response.Message == "TodoList not found")
        {
            return NotFound();
        }
        
        if (!response.Success && response.Message == "Unauthorized")
        {
            return Unauthorized();
        }
        
        return Ok(response);
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
    
    [HttpPut("updateTodoList")]
    public async Task<IActionResult> UpdateTodoList([FromQuery] UpdateCommandRequest request)
    {
        // var request = new UpdateCommandRequest {UserId = userId, TodoListId = id, Title = todoList.Title};
        
        var response = await _mediator.Send(request);
        
        if (!response.Success && response.Message == "TodoList not found")
        {
            return NotFound();
        }
        
        if (!response.Success && response.Message == "Unauthorized")
        {
            return Unauthorized();
        }
        
        return Ok(response.TodoList);
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