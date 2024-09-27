using MediatR;
using TodoBackend.Domain.Entities.TodoList;

namespace TodoBackend.Application.TodoLists.Update;

public class UpdateCommandHandler: IRequestHandler<UpdateCommandRequest, UpdateCommandResponse>
{
    private readonly ITodoListRepository _todoListRepository;
    
    public UpdateCommandHandler(ITodoListRepository todoListRepository)
    {
        _todoListRepository = todoListRepository;
    }
    
    public async Task<UpdateCommandResponse> Handle(UpdateCommandRequest request, CancellationToken cancellationToken)
    {
        var existingTodoList = await _todoListRepository.GetByIdAsync(request.TodoListId);
        if(existingTodoList == null)
        {
            return new UpdateCommandResponse
            {
                Success = false,
                Message = "TodoList not found",
                TodoList = null
            };
        }

        if (existingTodoList.UserId != request.UserId)
        {
            return new UpdateCommandResponse
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

        return new UpdateCommandResponse
        {
            Success = true,
            Message = "TodoList updated successfully",
            TodoList = existingTodoList
        };
    }
}