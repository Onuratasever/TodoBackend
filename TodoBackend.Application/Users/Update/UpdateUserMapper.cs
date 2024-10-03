using AutoMapper;
using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Application.Users.Update;

public class UpdateUserMapper : Profile
{
    public UpdateUserMapper()
    {
        CreateMap<UpdateUserCommandRequest, User>()
            .ForMember(dest => dest.FirstName,
                opt => opt.Condition(src => src.FirstName != null && src.FirstName.Length > 0))
            .ForMember(dest => dest.LastName,
                opt => opt.Condition(src => src.LastName != null && src.LastName.Length > 0))
            .ForMember(dest => dest.Username,
                opt => opt.Condition(src => src.Username != null && src.Username.Length > 0))
            .ForMember(dest => dest.Email,
                opt => opt.Condition(src => src.Email != null && src.Email.Length > 0))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now));
    }
}