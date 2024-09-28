using MediatR;
using TodoBackend.Domain.Entities.TodoList;

namespace TodoBackend.Application.TodoLists.Update;

public class UpdateTodoListCommandHandler: IRequestHandler<UpdateTodoListCommandRequest, UpdateTodoListCommandResponse>
{
    private readonly ITodoListRepository _todoListRepository;
    
    public UpdateTodoListCommandHandler(ITodoListRepository todoListRepository)
    {
        _todoListRepository = todoListRepository;
    }
    
    public async Task<UpdateTodoListCommandResponse> Handle(UpdateTodoListCommandRequest request, CancellationToken cancellationToken)
    {
        var existingTodoList = await _todoListRepository.GetByIdAsync(request.TodoListId);
        if(existingTodoList == null)
        {
            return new UpdateTodoListCommandResponse
            {
                Success = false,
                Message = "TodoList not found",
                TodoList = null
            };
        }

        if (existingTodoList.UserId != request.UserId)
        {
            return new UpdateTodoListCommandResponse
            {
                Success = false,
                Message = "Unauthorized",
                TodoList = null
            };
        }
        existingTodoList.Title = request.Title;
        existingTodoList.UpdatedAt = DateTime.Now;
        
        _todoListRepository.Update(existingTodoList);
        
        await _todoListRepository.SaveChangesAsync();

        return new UpdateTodoListCommandResponse
        {
            Success = true,
            Message = "TodoList updated successfully",
            TodoList = existingTodoList
        };
    }
}