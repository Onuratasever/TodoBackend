using MediatR;
using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Application.Users.Update;

public class UpdateCommandHandler: IRequestHandler<UpdateCommandRequest, UpdateCommandResponse>
{
    private readonly IUserRepository _userRepository;
    
    public UpdateCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<UpdateCommandResponse> Handle(UpdateCommandRequest request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(request.Id);
        if(existingUser == null)
        {
            return new UpdateCommandResponse
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

        return new UpdateCommandResponse
        {
            User = existingUser
        };
    }
}