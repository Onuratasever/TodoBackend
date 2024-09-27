using MediatR;

namespace TodoBackend.Application.TodoLists.Delete;

public class DeleteCommandRequest: IRequest<DeleteCommandResponse>
{
    public Guid UserId { get; set; }
    public Guid TodoListId { get; set; }
}