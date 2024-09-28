using FluentValidation;

namespace TodoBackend.Application.TodoLists.Update;

public class UpdateTodoListCommandValidator:AbstractValidator<UpdateTodoListCommandRequest>
{
    public UpdateTodoListCommandValidator()
    {
        RuleFor(x => x.TodoListId).NotEmpty().WithMessage("Todo list id is required");
        RuleFor(x => x.Title)
            .NotEmpty()
                .WithMessage("Title is required")
            .NotNull()
                .WithMessage("Title is required")
            .MaximumLength(50)
                .WithMessage("Title must not exceed 50 characters")
            .MinimumLength(3)
                .WithMessage("Title must be at least 3 characters");
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User id is required");
    }
}