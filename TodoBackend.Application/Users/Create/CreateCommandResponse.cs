using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Application.Users.Create;

public class CreateCommandResponse
{
    public User user { get; set; }
}