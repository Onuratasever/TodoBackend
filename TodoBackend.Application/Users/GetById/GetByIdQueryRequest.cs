using MediatR;

namespace TodoBackend.Application.Users.GetById;

public class GetByIdQueryRequest: IRequest<GetByIdQueryResponse>
{
    public Guid Id { get; set; }
}