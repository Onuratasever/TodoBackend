using MediatR;

namespace TodoBackend.Application.Users.Delete;

public class DeleteCommandRequest: IRequest<DeleteCommandResponse>
{
    public Guid Id { get; set; }
}