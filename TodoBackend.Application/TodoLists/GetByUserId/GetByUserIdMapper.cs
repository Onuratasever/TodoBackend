using AutoMapper;
using TodoBackend.Domain.Entities.TodoList;

namespace TodoBackend.Application.TodoLists.GetByUserId;

public class GetByUserIdMapper : Profile
{
    public GetByUserIdMapper()
    {
        CreateMap<List<TodoList>,GetTodoListByUserIdQueryResponse>()
            .ForMember(dest => dest.TodoListsList,opt => opt.MapFrom(src => src));
    }
}