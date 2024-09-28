using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Application.Users.GetById;

public class GetUserByIdQueryHandler: IRequestHandler<GetUserByIdQueryRequest, GetUserByIdQueryResponse>
{
    readonly private IUserRepository _userRepository;
    
    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<GetUserByIdQueryResponse> Handle(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);
        return new GetUserByIdQueryResponse
        {
            user = user
        };
    }
}