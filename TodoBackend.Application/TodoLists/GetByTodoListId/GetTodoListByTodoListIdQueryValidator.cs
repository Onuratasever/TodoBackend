using FluentValidation;

namespace TodoBackend.Application.TodoLists.GetByTodoListId;

public class GetTodoListByTodoListIdQueryValidator: AbstractValidator<GetTodoListByTodoListIdQueryRequest>
{
    public GetTodoListByTodoListIdQueryValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required");
        RuleFor(x => x.TodoListId).NotEmpty().WithMessage("TodoListId is required");
    }
}