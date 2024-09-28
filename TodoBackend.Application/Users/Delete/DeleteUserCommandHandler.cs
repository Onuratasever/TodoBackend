using MediatR;
using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Application.Users.Delete;

public class DeleteUserCommandHandler: IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
{
    private readonly IUserRepository _userRepository;
    
    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(request.Id);
        
        if (existingUser == null)
        {
            return new DeleteUserCommandResponse
            {
                Success = false,
                Message = "User not found"
            };
        }

        _userRepository.Delete(existingUser);
        
        await _userRepository.SaveChangesAsync();
        
        return new DeleteUserCommandResponse
        {
            Success = true,
            Message = "User successfully deleted"
        };
    }
}