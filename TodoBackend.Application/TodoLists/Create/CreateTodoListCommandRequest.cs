using MediatR;

namespace TodoBackend.Application.TodoLists.Create;

public class CreateTodoListCommandRequest:IRequest<CreateTodoListCommandResponse>
{
    public Guid UserId { get; set; }
    public string Title { get; set; }   
}