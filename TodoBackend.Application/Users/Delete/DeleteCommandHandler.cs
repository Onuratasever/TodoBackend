using MediatR;
using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Application.Users.Delete;

public class DeleteCommandHandler: IRequestHandler<DeleteCommandRequest, DeleteCommandResponse>
{
    private readonly IUserRepository _userRepository;
    
    public DeleteCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<DeleteCommandResponse> Handle(DeleteCommandRequest request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(request.Id);
        
        if (existingUser == null)
        {
            return new DeleteCommandResponse
            {
                Success = false,
                Message = "User not found"
            };
        }

        _userRepository.Delete(existingUser);
        
        await _userRepository.SaveChangesAsync();
        
        return new DeleteCommandResponse
        {
            Success = true,
            Message = "User successfully deleted"
        };
    }
}