using FluentValidation;

namespace TodoBackend.Application.TodoLists.GetByUserId;

public class GetTodoListByUserIdQueryValidator:AbstractValidator<GetTodoListByUserIdQueryRequest>
{
    public GetTodoListByUserIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("User id is required");
    }
}