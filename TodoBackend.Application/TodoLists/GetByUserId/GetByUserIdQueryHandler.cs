using MediatR;
using TodoBackend.Domain.Entities.TodoList;

namespace TodoBackend.Application.TodoLists.GetByUserId;

public class GetByUserIdQueryHandler:IRequestHandler<GetByUserIdQueryRequest,GetByUserIdQueryResponse>
{
    private readonly ITodoListRepository _todoListRepository;
    
    public GetByUserIdQueryHandler(ITodoListRepository todoListRepository)
    {
        _todoListRepository = todoListRepository;
    }
    
    public async Task<GetByUserIdQueryResponse> Handle(GetByUserIdQueryRequest request, CancellationToken cancellationToken)
    {
        var todoLists = await _todoListRepository.GetListAsync(user => user.UserId == request.Id);
        return new GetByUserIdQueryResponse
        {
            TodoListsList = todoLists.ToList()
        };
    }
}