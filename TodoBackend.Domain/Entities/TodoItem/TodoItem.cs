using TodoBackend.Domain.Entities.Common;

namespace TodoBackend.Domain.Entities.TodoItem;

public class TodoItem: BaseEntity
{
    public Guid TodoListId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public DateTime DueDate { get; set; }
    
}