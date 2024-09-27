using MediatR;

namespace TodoBackend.Application.TodoLists.GetByUserId;

public class GetByUserIdQueryRequest:IRequest<GetByUserIdQueryResponse>
{
    public Guid Id { get; set; }
}