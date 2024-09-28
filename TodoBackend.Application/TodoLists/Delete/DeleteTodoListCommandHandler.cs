using MediatR;
using TodoBackend.Domain.Entities.TodoList;

namespace TodoBackend.Application.TodoLists.Delete;

public class DeleteTodoListCommandHandler:IRequestHandler<DeleteTodoListCommandRequest, DeleteTodoListCommandResponse>
{
    private readonly ITodoListRepository _todoListRepository;
    
    public DeleteTodoListCommandHandler(ITodoListRepository todoListRepository)
    {
        _todoListRepository = todoListRepository;
    }
    public async Task<DeleteTodoListCommandResponse> Handle(DeleteTodoListCommandRequest request, CancellationToken cancellationToken)
    {
        var existingTodoList = await _todoListRepository.GetByIdAsync(request.TodoListId);
        if(existingTodoList == null)
        {
            return new DeleteTodoListCommandResponse
            {
                Success = false,
                Message = "TodoList not found"
            };
        }

        if (existingTodoList.UserId != request.UserId)
        {
            return new DeleteTodoListCommandResponse
            {
                Success = false,
                Message = "Unauthorized"
            };
        }
        
        _todoListRepository.Delete(existingTodoList);
        
        await _todoListRepository.SaveChangesAsync();
        return new DeleteTodoListCommandResponse
        {
            Success = true,
            Message = "TodoList deleted successfully"
        };
    }
}