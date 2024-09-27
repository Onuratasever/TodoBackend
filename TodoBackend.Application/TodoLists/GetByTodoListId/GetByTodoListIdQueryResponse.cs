using TodoBackend.Domain.Entities.TodoList;

namespace TodoBackend.Application.TodoLists.GetByTodoListId;

public class GetByTodoListIdQueryResponse
{
    public TodoList? TodoList { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
}