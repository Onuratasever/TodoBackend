using MediatR;
using TodoBackend.Domain.Entities.TodoList;

namespace TodoBackend.Application.TodoLists.GetByTodoListId;

public class GetByTodoListIdQueryHandler:IRequestHandler<GetByTodoListIdQueryRequest,GetByTodoListIdQueryResponse>
{
    private readonly ITodoListRepository _todoListRepository;
    
    public GetByTodoListIdQueryHandler(ITodoListRepository todoListRepository)
    {
        _todoListRepository = todoListRepository;
    }
    
    public async Task<GetByTodoListIdQueryResponse> Handle(GetByTodoListIdQueryRequest request, CancellationToken cancellationToken)
    {
        var todoList = await _todoListRepository.GetByIdAsync(request.TodoListId);
        if (todoList == null)
        {
            return new GetByTodoListIdQueryResponse
            {
                Success = false,
                Message = "TodoList not found",
                TodoList = null
            };
        }
        
        if (request.UserId != todoList.UserId)
        {
            return new GetByTodoListIdQueryResponse
            {
                Success = false,
                Message = "Unauthorized",
                TodoList = null
            };    
        }

        return new GetByTodoListIdQueryResponse
        {
            Success = true,
            Message = "TodoList found",
            TodoList = todoList
        };
    }
}