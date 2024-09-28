using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Application.Users.Create;

public class CreateUserCommandResponse
{
    public User user { get; set; }
}