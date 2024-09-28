using MediatR;

namespace TodoBackend.Application.TodoLists.Delete;

public class DeleteTodoListCommandRequest: IRequest<DeleteTodoListCommandResponse>
{
    public Guid UserId { get; set; }
    public Guid TodoListId { get; set; }
}