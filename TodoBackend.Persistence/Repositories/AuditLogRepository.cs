using TodoBackend.Domain.Entities.AuditLog;

namespace TodoBackend.Persistence.Repositories;

public class AuditLogRepository: Repository<AuditLog>, IAuditLogRepository
{
    public AuditLogRepository(ApplicationDbContext context) : base(context)
    {
    }
}