using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Application.Users.Update;

public class UpdateCommandResponse
{
    public User? User { get; set; }
}