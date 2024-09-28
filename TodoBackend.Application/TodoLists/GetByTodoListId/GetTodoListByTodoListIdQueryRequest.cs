using MediatR;

namespace TodoBackend.Application.TodoLists.GetByTodoListId;

public class GetTodoListByTodoListIdQueryRequest:IRequest<GetTodoListByTodoListIdQueryResponse>
{
    public Guid TodoListId { get; set; }
    public Guid UserId { get; set; }
}