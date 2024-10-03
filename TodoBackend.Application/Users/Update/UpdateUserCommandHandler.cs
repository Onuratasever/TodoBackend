using MediatR;
using AutoMapper;
using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Application.Users.Update;

public class UpdateUserCommandHandler: IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(request.Id);
        if(existingUser == null)
        {
            return new UpdateUserCommandResponse
            {
                User = null
            };
        }

        _mapper.Map(request, existingUser);
        
        await _userRepository.SaveChangesAsync();

        return new UpdateUserCommandResponse
        {
            User = existingUser
        };
    }
}