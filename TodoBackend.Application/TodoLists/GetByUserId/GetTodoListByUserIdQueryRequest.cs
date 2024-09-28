using MediatR;

namespace TodoBackend.Application.TodoLists.GetByUserId;

public class GetTodoListByUserIdQueryRequest:IRequest<GetTodoListByUserIdQueryResponse>
{
    public Guid Id { get; set; }
}