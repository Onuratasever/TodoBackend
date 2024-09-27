using MediatR;
using TodoBackend.Domain.Entities.TodoList;

namespace TodoBackend.Application.TodoLists.Create;

public class CreateCommandHandler:IRequestHandler<CreateCommandRequest, CreateCommandResponse>
{
    private readonly ITodoListRepository _todoListRepository;
    
    public CreateCommandHandler(ITodoListRepository todoListRepository)
    {
        _todoListRepository = todoListRepository;
    }
    public async Task<CreateCommandResponse> Handle(CreateCommandRequest request, CancellationToken cancellationToken)
    {
        var todoList = new TodoList
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            UserId = request.UserId,
            Title = request.Title
        };
        
        _todoListRepository.Add(todoList);
        
        await _todoListRepository.SaveChangesAsync();
        
        return new CreateCommandResponse
        {
            TodoList = todoList
        };

    }
}