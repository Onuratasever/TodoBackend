using Microsoft.AspNetCore.Mvc;
using TodoBackend.Domain.Entities.SubTask;
using TodoBackend.Domain.Entities.TodoItem;
using TodoBackend.Domain.Entities.TodoList;

namespace TodoBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubTasksController: ControllerBase
{
    private readonly ISubTaskRepository _subTaskRepository;
    private readonly ITodoItemRepository _todoItemRepository;
    private readonly ITodoListRepository _todoListRepository;
    
    public SubTasksController(ISubTaskRepository subTaskRepository, ITodoItemRepository todoItemRepository, ITodoListRepository todoListRepository)
    {
        _subTaskRepository = subTaskRepository;
        _todoItemRepository = todoItemRepository;
        _todoListRepository = todoListRepository;
    }
    
    [HttpGet("{userId:guid}/todolists/{todoListId:guid}/items/{todoItemId:guid}/subtasks")]
    public async Task<IActionResult> GetSubTasks(Guid userId, Guid todoListId, Guid todoItemId)
    {
        var todoItem = await _todoItemRepository.GetByIdAsync(todoItemId);
        if (todoItem == null)
        {
            return NotFound();
        }
        
        var todoList = await _todoListRepository.GetByIdAsync(todoListId);
        if (todoList == null)
        {
            return NotFound();
        }
        
        if (todoList.UserId != userId)
        {
            return Unauthorized();
        }
        
        if (todoItem.TodoListId != todoListId)
        {
            return BadRequest();
        }
        
        var subTasks = await _subTaskRepository.GetListAsync(subTask => subTask.MainTaskId == todoItemId);
        return Ok(subTasks);
    }
    
    [HttpPost("{userId:guid}/todolists/{todoListId:guid}/items/{todoItemId:guid}/subtasks")]
    public async Task<IActionResult> CreateSubTask(Guid userId, Guid todoListId, Guid todoItemId, SubTask subTask)
    {
        var todoItem = await _todoItemRepository.GetByIdAsync(todoItemId);
        if (todoItem == null)
        {
            return NotFound();
        }
        
        var todoList = await _todoListRepository.GetByIdAsync(todoListId);
        if (todoList == null)
        {
            return NotFound();
        }
        
        if (todoList.UserId != userId)
        {
            return Unauthorized();
        }
        
        if (todoItem.TodoListId != todoListId)
        {
            return BadRequest();
        }
        
        subTask.Id = Guid.NewGuid();
        subTask.MainTaskId = todoItemId;
        subTask.CreatedAt = DateTime.Now;
        subTask.UpdatedAt = DateTime.Now;
        subTask.Description = subTask.Description;
        subTask.DueDate = subTask.DueDate;
        subTask.IsCompleted = subTask.IsCompleted;
        subTask.priority = subTask.priority;
        subTask.Title = subTask.Title;
        
        _subTaskRepository.Add(subTask);
        
        await _subTaskRepository.SaveChangesAsync();
        return Ok(subTask);
    }
    
    [HttpPut("{userId:guid}/todolists/{todoListId:guid}/items/{todoItemId:guid}/subtasks/{subTaskId:guid}")]
    public async Task<IActionResult> UpdateSubTask(Guid userId, Guid todoListId, Guid todoItemId, Guid subTaskId, SubTask subTask)
    {
        var todoItem = await _todoItemRepository.GetByIdAsync(todoItemId);
        if (todoItem == null)
        {
            return NotFound();
        }
        
        var todoList = await _todoListRepository.GetByIdAsync(todoListId);
        if (todoList == null)
        {
            return NotFound();
        }
        
        if (todoList.UserId != userId)
        {
            return Unauthorized();
        }
        
        if (todoItem.TodoListId != todoListId)
        {
            return BadRequest();
        }
        
        var existingSubTask = await _subTaskRepository.GetByIdAsync(subTaskId);
        if (existingSubTask == null)
        {
            return NotFound();
        }
        
        if (existingSubTask.MainTaskId != todoItemId)
        {
            return BadRequest();
        }
        
        existingSubTask.Title = subTask.Title;
        existingSubTask.Description = subTask.Description;
        existingSubTask.priority = subTask.priority;
        existingSubTask.IsCompleted = subTask.IsCompleted;
        existingSubTask.DueDate = subTask.DueDate;
        existingSubTask.UpdatedAt = DateTime.Now;
        
        await _subTaskRepository.SaveChangesAsync();
        return Ok(existingSubTask);
    }
    
    [HttpDelete("{userId:guid}/todolists/{todoListId:guid}/items/{todoItemId:guid}/subtasks/{subTaskId:guid}")]
    public async Task<IActionResult> DeleteSubTask(Guid userId, Guid todoListId, Guid todoItemId, Guid subTaskId)
    {
        var todoItem = await _todoItemRepository.GetByIdAsync(todoItemId);
        if (todoItem == null)
        {
            return NotFound();
        }
        
        var todoList = await _todoListRepository.GetByIdAsync(todoListId);
        if (todoList == null)
        {
            return NotFound();
        }
        
        if (todoList.UserId != userId)
        {
            return Unauthorized();
        }
        
        if (todoItem.TodoListId != todoListId)
        {
            return BadRequest();
        }
        
        var existingSubTask = await _subTaskRepository.GetByIdAsync(subTaskId);
        if (existingSubTask == null)
        {
            return NotFound();
        }
        
        if (existingSubTask.MainTaskId != todoItemId)
        {
            return BadRequest();
        }
        
        _subTaskRepository.Delete(existingSubTask);
        
        await _subTaskRepository.SaveChangesAsync();
        return Ok();
    }
}