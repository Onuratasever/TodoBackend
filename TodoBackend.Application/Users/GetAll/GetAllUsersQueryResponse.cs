using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Application.Users.GetAll;

public class GetAllUsersQueryResponse
{
    public List<User> _users { get; set; }
}