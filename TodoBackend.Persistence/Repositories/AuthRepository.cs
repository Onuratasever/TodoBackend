using TodoBackend.Domain.Entities.Auth;

namespace TodoBackend.Persistence.Repositories;

public class AuthRepository: Repository<Auth>, IAuthRepository
{   
    public AuthRepository(ApplicationDbContext context) : base(context)
    {
    }
}