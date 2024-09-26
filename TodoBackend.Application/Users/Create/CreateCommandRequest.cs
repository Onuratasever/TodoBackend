using MediatR;
using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Application.Users.Create;

public class CreateCommandRequest:IRequest<CreateCommandResponse>
{
    public User User { get; set; }
}