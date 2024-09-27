using MediatR;
using TodoBackend.Domain.Entities.TodoList;

namespace TodoBackend.Application.TodoLists.Update;

public class UpdateCommandRequest: IRequest<UpdateCommandResponse>
{
    public Guid UserId { get; set; }
    public Guid TodoListId { get; set; }
    public string Title { get; set; }
}