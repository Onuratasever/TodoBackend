using AutoMapper;
using MediatR;
using TodoBackend.Domain.Entities.TodoList;

namespace TodoBackend.Application.TodoLists.Create;

public class CreateTodoListCommandHandler:IRequestHandler<CreateTodoListCommandRequest, CreateTodoListCommandResponse>
{
    private readonly ITodoListRepository _todoListRepository;
    private readonly IMapper _mapper;
    public CreateTodoListCommandHandler(ITodoListRepository todoListRepository, IMapper mapper)
    {
        _todoListRepository = todoListRepository;
        _mapper = mapper;
    }
    public async Task<CreateTodoListCommandResponse> Handle(CreateTodoListCommandRequest request, CancellationToken cancellationToken)
    {
        var todoList = _mapper.Map<TodoList>(request);
        
        _todoListRepository.Add(todoList);
        
        await _todoListRepository.SaveChangesAsync();
        
        return new CreateTodoListCommandResponse
        {
            TodoList = todoList
        };

    }
}