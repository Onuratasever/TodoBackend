using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Application.Users.GetById;

public class GetUserByIdQueryHandler: IRequestHandler<GetUserByIdQueryRequest, GetUserByIdQueryResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    
    public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<GetUserByIdQueryResponse> Handle(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        return _mapper.Map<GetUserByIdQueryResponse>(user);
    }
}