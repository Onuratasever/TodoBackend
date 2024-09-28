using TodoBackend.Domain.Entities.TodoList;

namespace TodoBackend.Application.TodoLists.Update;

public class UpdateTodoListCommandResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public TodoList TodoList { get; set; }
}