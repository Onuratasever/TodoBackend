using AutoMapper;
using MediatR;
using TodoBackend.Domain.Entities.TodoList;

namespace TodoBackend.Application.TodoLists.GetByUserId;

public class GetTodoListByUserIdQueryHandler:IRequestHandler<GetTodoListByUserIdQueryRequest,GetTodoListByUserIdQueryResponse>
{
    private readonly ITodoListRepository _todoListRepository;
    private readonly IMapper _mapper;
    public GetTodoListByUserIdQueryHandler(ITodoListRepository todoListRepository, IMapper mapper)
    {
        _todoListRepository = todoListRepository;
        _mapper = mapper;
    }
    
    public async Task<GetTodoListByUserIdQueryResponse> Handle(GetTodoListByUserIdQueryRequest request, CancellationToken cancellationToken)
    {
        var todoLists = await _todoListRepository.GetListAsync(user => user.UserId == request.Id);
        return _mapper.Map<GetTodoListByUserIdQueryResponse>(todoLists);
    }
}