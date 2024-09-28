using FluentValidation;

namespace TodoBackend.Application.TodoLists.Delete;

public class DeleteTodoListCommandValidator: AbstractValidator<DeleteTodoListCommandRequest>
{
    public DeleteTodoListCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required");
        RuleFor(x => x.TodoListId).NotEmpty().WithMessage("TodoListId is required");
    }
}