using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Persistence.Repositories;

public class UserRepository:Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }
}