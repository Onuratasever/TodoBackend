using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Application.Users.GetById;

public class GetByIdQueryResponse
{
    public User? user { get; set; }
}