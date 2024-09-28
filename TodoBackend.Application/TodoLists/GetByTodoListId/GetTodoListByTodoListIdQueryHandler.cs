using MediatR;
using TodoBackend.Domain.Entities.TodoList;

namespace TodoBackend.Application.TodoLists.GetByTodoListId;

public class GetTodoListByTodoListIdQueryHandler:IRequestHandler<GetTodoListByTodoListIdQueryRequest,GetTodoListByTodoListIdQueryResponse>
{
    private readonly ITodoListRepository _todoListRepository;
    
    public GetTodoListByTodoListIdQueryHandler(ITodoListRepository todoListRepository)
    {
        _todoListRepository = todoListRepository;
    }
    
    public async Task<GetTodoListByTodoListIdQueryResponse> Handle(GetTodoListByTodoListIdQueryRequest request, CancellationToken cancellationToken)
    {
        var todoList = await _todoListRepository.GetByIdAsync(request.TodoListId);
        if (todoList == null)
        {
            return new GetTodoListByTodoListIdQueryResponse
            {
                Success = false,
                Message = "TodoList not found",
                TodoList = null
            };
        }
        
        if (request.UserId != todoList.UserId)
        {
            return new GetTodoListByTodoListIdQueryResponse
            {
                Success = false,
                Message = "Unauthorized",
                TodoList = null
            };    
        }

        return new GetTodoListByTodoListIdQueryResponse
        {
            Success = true,
            Message = "TodoList found",
            TodoList = todoList
        };
    }
}