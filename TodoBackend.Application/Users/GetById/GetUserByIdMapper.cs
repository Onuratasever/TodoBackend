using AutoMapper;
using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Application.Users.GetById;

public class GetUserByIdMapper: Profile
{
    public GetUserByIdMapper()
    {
        CreateMap<User, GetUserByIdQueryResponse>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src))
            /*.ForMember(dest => dest.User.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.User.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.User.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.User.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.User.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt))
            .ForMember(dest => dest.User.Role, opt => opt.MapFrom(src => src.Role))*/;
    }
}