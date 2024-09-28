using FluentValidation;

namespace TodoBackend.Application.Users.Update;

public class UpdateUserCommandValidator: AbstractValidator<UpdateUserCommandRequest>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty");
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email cannot be empty")
            .EmailAddress();
        

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First Name is required")
            .NotNull()
            .WithMessage("First Name is required")
            .MinimumLength(2)
            .MaximumLength(50);
        

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last Name is required")
            .NotNull()
            .WithMessage("Last Name is required")
            .MinimumLength(2)
            .MaximumLength(50);
        
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("Username is required")
            .NotNull()
            .WithMessage("Username is required")
            .MinimumLength(2)
            .MaximumLength(50);
    }
}