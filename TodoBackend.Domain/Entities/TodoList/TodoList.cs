using TodoBackend.Domain.Entities.Common;

namespace TodoBackend.Domain.Entities.TodoList;

public class TodoList: BaseEntity
{
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}