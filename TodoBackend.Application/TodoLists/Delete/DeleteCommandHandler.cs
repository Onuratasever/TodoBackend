using MediatR;
using TodoBackend.Domain.Entities.TodoList;

namespace TodoBackend.Application.TodoLists.Delete;

public class DeleteCommandHandler:IRequestHandler<DeleteCommandRequest, DeleteCommandResponse>
{
    private readonly ITodoListRepository _todoListRepository;
    
    public DeleteCommandHandler(ITodoListRepository todoListRepository)
    {
        _todoListRepository = todoListRepository;
    }
    public async Task<DeleteCommandResponse> Handle(DeleteCommandRequest request, CancellationToken cancellationToken)
    {
        var existingTodoList = await _todoListRepository.GetByIdAsync(request.TodoListId);
        if(existingTodoList == null)
        {
            return new DeleteCommandResponse
            {
                Success = false,
                Message = "TodoList not found"
            };
        }

        if (existingTodoList.UserId != request.UserId)
        {
            return new DeleteCommandResponse
            {
                Success = false,
                Message = "Unauthorized"
            };
        }
        
        _todoListRepository.Delete(existingTodoList);
        
        await _todoListRepository.SaveChangesAsync();
        return new DeleteCommandResponse
        {
            Success = true,
            Message = "TodoList deleted successfully"
        };
    }
}