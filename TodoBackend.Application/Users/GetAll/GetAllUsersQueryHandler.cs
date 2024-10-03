using AutoMapper;
using MediatR;
using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Application.Users.GetAll;

public class GetAllUsersQueryHandler: IRequestHandler<GetAllUsersQueryRequest, GetAllUsersQueryResponse> 
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<GetAllUsersQueryResponse> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync();
        
        return _mapper.Map<GetAllUsersQueryResponse>(users);
    }
}