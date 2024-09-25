using TodoBackend.Domain.Repositories;

namespace TodoBackend.Domain.Entities.AuditLog;

public interface IAuditLogRepository: IRepository<AuditLog>
{
}