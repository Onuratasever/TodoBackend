using MediatR;

namespace TodoBackend.Application.TodoLists.GetByTodoListId;

public class GetByTodoListIdQueryRequest:IRequest<GetByTodoListIdQueryResponse>
{
    public Guid TodoListId { get; set; }
    public Guid UserId { get; set; }
}