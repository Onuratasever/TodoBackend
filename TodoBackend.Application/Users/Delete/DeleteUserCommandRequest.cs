using MediatR;

namespace TodoBackend.Application.Users.Delete;

public class DeleteUserCommandRequest: IRequest<DeleteUserCommandResponse>
{
    public Guid Id { get; set; }
}