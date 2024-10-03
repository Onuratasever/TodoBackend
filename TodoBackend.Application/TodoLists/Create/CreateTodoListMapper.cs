using AutoMapper;
using TodoBackend.Domain.Entities.TodoList;

namespace TodoBackend.Application.TodoLists.Create;

public class CreateTodoListMapper: Profile
{
    public CreateTodoListMapper()
    {
        CreateMap<CreateTodoListCommandRequest, TodoList>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
    }
}