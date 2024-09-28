using MediatR;
using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Application.Users.Create;

public class CreateUserCommandRequest:IRequest<CreateUserCommandResponse>
{
    public User User { get; set; }
}