using TodoBackend.Domain.Entities.TodoItem;

namespace TodoBackend.Persistence.Repositories;

public class TodoItemRepository:Repository<TodoItem>, ITodoItemRepository
{
    public TodoItemRepository(ApplicationDbContext context) : base(context)
    {
    }
}