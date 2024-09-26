using MediatR;
using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Application.Users.GetAll;

public class GetAllQueryHandler: IRequestHandler<GetAllQueryRequest, GetAllQueryResponse> 
{
    readonly private IUserRepository _userRepository;
    
    public GetAllQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<GetAllQueryResponse> Handle(GetAllQueryRequest request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync();
        return new GetAllQueryResponse
        {
            _users = users
        };
    }
}