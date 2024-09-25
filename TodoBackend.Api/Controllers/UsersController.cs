using Microsoft.AspNetCore.Mvc;
using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController: ControllerBase
{
    readonly private IUserRepository _userRepository;
    
    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    [HttpGet]
    public async Task Get()
    {
         _userRepository.Add(new()
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Username = "johndoe",
                Email = "email",
                CreatedAt = DateTime.Now,//.ToString("MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture),
                Role = "Admin",
                UpdatedAt = DateTime.Now
            }
        );
        await _userRepository.SaveChangesAsync();
    }
}