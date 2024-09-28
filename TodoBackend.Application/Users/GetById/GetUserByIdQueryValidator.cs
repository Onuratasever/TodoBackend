using FluentValidation;

namespace TodoBackend.Application.Users.GetById;

public class GetUserByIdQueryValidator: AbstractValidator<GetUserByIdQueryRequest>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty");
    }
}