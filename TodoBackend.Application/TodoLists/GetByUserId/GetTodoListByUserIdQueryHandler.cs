using MediatR;
using TodoBackend.Domain.Entities.TodoList;

namespace TodoBackend.Application.TodoLists.GetByUserId;

public class GetTodoListByUserIdQueryHandler:IRequestHandler<GetTodoListByUserIdQueryRequest,GetTodoListByUserIdQueryResponse>
{
    private readonly ITodoListRepository _todoListRepository;
    
    public GetTodoListByUserIdQueryHandler(ITodoListRepository todoListRepository)
    {
        _todoListRepository = todoListRepository;
    }
    
    public async Task<GetTodoListByUserIdQueryResponse> Handle(GetTodoListByUserIdQueryRequest request, CancellationToken cancellationToken)
    {
        var todoLists = await _todoListRepository.GetListAsync(user => user.UserId == request.Id);
        return new GetTodoListByUserIdQueryResponse
        {
            TodoListsList = todoLists.ToList()
        };
    }
}