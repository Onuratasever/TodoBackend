using FluentValidation;

namespace TodoBackend.Application.TodoLists.Create;

public class CreateTodoListCommandValidator: AbstractValidator<CreateTodoListCommandRequest>
{
    public CreateTodoListCommandValidator()
    {
        RuleFor(x =>   x.UserId).NotEmpty().WithMessage("UserId is required");
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
    }
}