using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Application.Users.Update;

public class UpdateUserCommandResponse
{
    public User? User { get; set; }
}