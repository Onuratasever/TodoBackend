using MediatR;

namespace TodoBackend.Application.Users.GetById;

public class GetUserByIdQueryRequest: IRequest<GetUserByIdQueryResponse>
{
    public Guid Id { get; set; }
}