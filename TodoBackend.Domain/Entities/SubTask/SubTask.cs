using TodoBackend.Domain.Entities.Common;

namespace TodoBackend.Domain.Entities.SubTask;

public class SubTask: BaseEntity
{
    public Guid MainTaskId { get; set; }
    public string Description { get; set; }
    public string priority { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Title { get; set; }
}