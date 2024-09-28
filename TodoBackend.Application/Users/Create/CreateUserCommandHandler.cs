using MediatR;
using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Application.Users.Create;

public class CreateUserCommandHandler: IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    private readonly IUserRepository _userRepository;
    
    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        request.User.Id = Guid.NewGuid();
        request.User.CreatedAt = DateTime.Now;
        request.User.UpdatedAt = DateTime.Now;
        
        _userRepository.Add(request.User);
        
        await _userRepository.SaveChangesAsync();

        return new CreateUserCommandResponse
        {
            user = request.User
        };
    }
}