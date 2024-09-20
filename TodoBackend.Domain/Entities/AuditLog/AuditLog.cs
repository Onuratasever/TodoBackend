using TodoBackend.Domain.Entities.Common;

namespace TodoBackend.Domain.Entities.AuditLog;

public class AuditLog: BaseEntity
{
    public Guid UserId { get; set; }
    public string Action { get; set; }
    public DateTime ChangeDateTime { get; set; }
}