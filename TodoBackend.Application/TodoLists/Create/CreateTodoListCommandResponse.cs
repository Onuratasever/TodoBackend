using TodoBackend.Domain.Entities.TodoList;

namespace TodoBackend.Application.TodoLists.Create;

public class CreateTodoListCommandResponse
{
    public TodoList TodoList { get; set; } 
}