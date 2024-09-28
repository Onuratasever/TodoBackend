using MediatR;
using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Application.Users.Update;

public class UpdateUserCommandHandler: IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
{
    private readonly IUserRepository _userRepository;
    
    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
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
        
        if(request.FirstName != null && request.FirstName.Length > 0)
        {
            existingUser.FirstName = request.FirstName;
        }
        if(request.LastName != null && request.LastName.Length > 0)
        {
            existingUser.LastName = request.LastName;
        }
        if(request.Username != null && request.Username.Length > 0)
        {
            existingUser.Username = request.Username;
        }
        if(request.Email != null && request.Email.Length > 0)
        {
            existingUser.Email = request.Email;
        }
        existingUser.UpdatedAt = DateTime.Now;
        
        _userRepository.Update(existingUser);
        
        await _userRepository.SaveChangesAsync();

        return new UpdateUserCommandResponse
        {
            User = existingUser
        };
    }
}