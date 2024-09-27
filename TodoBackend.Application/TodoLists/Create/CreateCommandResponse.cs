using TodoBackend.Domain.Entities.TodoList;

namespace TodoBackend.Application.TodoLists.Create;

public class CreateCommandResponse
{
    public TodoList TodoList { get; set; } 
}