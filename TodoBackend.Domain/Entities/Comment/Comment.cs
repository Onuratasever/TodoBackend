using TodoBackend.Domain.Entities.Common;

namespace TodoBackend.Domain.Entities.Comment;

public class Comment: BaseEntity
{
    public Guid TodoId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid UserId { get; set; }
}