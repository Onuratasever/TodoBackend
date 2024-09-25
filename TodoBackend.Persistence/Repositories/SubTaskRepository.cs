using TodoBackend.Domain.Entities.SubTask;

namespace TodoBackend.Persistence.Repositories;

public class SubTaskRepository: Repository<SubTask>, ISubTaskRepository
{
    public SubTaskRepository(ApplicationDbContext context) : base(context)
    {
    }
}