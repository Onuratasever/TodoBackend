using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Application.Users.GetById;

public class GetUserByIdQueryResponse
{
    public User? user { get; set; }
}