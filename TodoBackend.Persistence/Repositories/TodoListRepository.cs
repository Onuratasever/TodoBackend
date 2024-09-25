using TodoBackend.Domain.Entities.TodoList;

namespace TodoBackend.Persistence.Repositories;

public class TodoListRepository: Repository<TodoList>, ITodoListRepository
{
    public TodoListRepository(ApplicationDbContext context) : base(context)
    {
    }
}