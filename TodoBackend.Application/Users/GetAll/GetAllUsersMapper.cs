using AutoMapper;
using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Application.Users.GetAll;

public class GetAllUsersMapper : Profile
{
    public GetAllUsersMapper()
    {
        CreateMap<List<User>, GetAllUsersQueryResponse>()
            .ForMember(dest => dest._users, opt => opt.MapFrom(src => src));

    }
}