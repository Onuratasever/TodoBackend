using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Application.Users.GetById;

public class GetByIdQueryHandler: IRequestHandler<GetByIdQueryRequest, GetByIdQueryResponse>
{
    readonly private IUserRepository _userRepository;
    
    public GetByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<GetByIdQueryResponse> Handle(GetByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);
        return new GetByIdQueryResponse
        {
            user = user
        };
    }
}