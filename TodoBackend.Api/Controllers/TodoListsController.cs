using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoBackend.Application.TodoLists.Create;
using TodoBackend.Application.TodoLists.Delete;
using TodoBackend.Application.TodoLists.GetByTodoListId;
using TodoBackend.Application.TodoLists.GetByUserId;
using TodoBackend.Application.TodoLists.Update;
using TodoBackend.Domain.Entities.TodoList;

namespace TodoBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoListsController: ControllerBase
{
    private readonly  ITodoListRepository _todoListRepository;
    private readonly IMediator _mediator;
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
    
    [HttpPost("createTodoList")]
    public async Task<IActionResult> CreateTodoList([FromQuery] CreateCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response.TodoList);
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
    
    [HttpDelete("deleteTodoList")]
    public async Task<IActionResult> DeleteTodoList([FromQuery] DeleteCommandRequest request)
    {
        var response = await _mediator.Send(request);
        if (!response.Success && response.Message == "TodoList not found")
        {
            return NotFound();
        }
        
        if (!response.Success && response.Message == "Unauthorized")
        {
            return Unauthorized();
        }
        
        return Ok();
    }
}