using MediatR;
using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Application.Users.GetAll;

public class GetAllUsersQueryHandler: IRequestHandler<GetAllUsersQueryRequest, GetAllUsersQueryResponse> 
{
    readonly private IUserRepository _userRepository;
    
    public GetAllUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<GetAllUsersQueryResponse> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync();
        return new GetAllUsersQueryResponse
        {
            _users = users
        };
    }
}