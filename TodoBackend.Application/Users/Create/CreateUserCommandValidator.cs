// using System.ComponentModel.DataAnnotations;
using FluentValidation;
// using FluentValidation.Validators;

namespace TodoBackend.Application.Users.Create;

public class CreateUserCommandValidator: AbstractValidator<CreateUserCommandRequest>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.User.Email)
            .NotEmpty()
                .WithMessage("Email cannot be empty")
            .EmailAddress();
        

        RuleFor(x => x.User.FirstName)
            .NotEmpty()
                .WithMessage("First Name is required")
            .NotNull()
                .WithMessage("First Name is required")
            .MinimumLength(2)
            .MaximumLength(50);
        

        RuleFor(x => x.User.LastName)
            .NotEmpty()
            .WithMessage("Last Name is required")
            .NotNull()
                .WithMessage("Last Name is required")
            .MinimumLength(2)
            .MaximumLength(50);
        
        RuleFor(x => x.User.Username)
            .NotEmpty()
            .WithMessage("Username is required")
            .NotNull()
                .WithMessage("Username is required")
            .MinimumLength(2)
            .MaximumLength(50);
    }
}