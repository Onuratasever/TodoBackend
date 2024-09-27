using TodoBackend.Domain.Entities.TodoList;

namespace TodoBackend.Application.TodoLists.GetByUserId;

public class GetByUserIdQueryResponse
{
    public List<TodoList> TodoListsList { get; set; }
}