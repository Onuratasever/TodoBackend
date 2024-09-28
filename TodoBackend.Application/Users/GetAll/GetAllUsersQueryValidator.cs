using FluentValidation;

namespace TodoBackend.Application.Users.GetAll;

public class GetAllUsersQueryValidator: AbstractValidator<GetAllUsersQueryRequest>
{
    public GetAllUsersQueryValidator()
    {
        //no rules
    }
}