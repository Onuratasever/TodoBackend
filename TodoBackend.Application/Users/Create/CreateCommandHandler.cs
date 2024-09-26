using MediatR;
using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Application.Users.Create;

public class CreateCommandHandler: IRequestHandler<CreateCommandRequest, CreateCommandResponse>
{
    private readonly IUserRepository _userRepository;
    
    public CreateCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<CreateCommandResponse> Handle(CreateCommandRequest request, CancellationToken cancellationToken)
    {
        request.User.Id = Guid.NewGuid();
        request.User.CreatedAt = DateTime.Now;
        request.User.UpdatedAt = DateTime.Now;
        
        _userRepository.Add(request.User);
        
        await _userRepository.SaveChangesAsync();

        return new CreateCommandResponse
        {
            user = request.User
        };
    }
}