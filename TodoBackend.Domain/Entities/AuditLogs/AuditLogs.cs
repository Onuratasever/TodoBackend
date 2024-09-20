using TodoBackend.Domain.Entities.Common;

namespace TodoBackend.Domain.Entities.AuditLogs;

public class AuditLogs: BaseEntity
{
    public Guid UserId { get; set; }
    public string Action { get; set; }
    public DateTime ChangeDateTime { get; set; }
}