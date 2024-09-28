using FluentValidation;

namespace TodoBackend.Application.Users.Delete;

public class DeleteUserCommandValidator: AbstractValidator<DeleteUserCommandRequest>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
                .WithMessage("Id cannot be empty");
    }
}