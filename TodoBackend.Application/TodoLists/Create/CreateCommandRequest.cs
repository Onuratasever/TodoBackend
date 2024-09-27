using MediatR;

namespace TodoBackend.Application.TodoLists.Create;

public class CreateCommandRequest:IRequest<CreateCommandResponse>
{
    public Guid UserId { get; set; }
    public string Title { get; set; }   
}