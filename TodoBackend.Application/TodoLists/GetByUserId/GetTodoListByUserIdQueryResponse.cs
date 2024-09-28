using TodoBackend.Domain.Entities.TodoList;

namespace TodoBackend.Application.TodoLists.GetByUserId;

public class GetTodoListByUserIdQueryResponse
{
    public List<TodoList> TodoListsList { get; set; }
}