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
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
    
    [HttpGet("getAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userRepository.GetAllAsync();
        return Ok(users);
    }
    
    [HttpPost("createUser")]
    public async Task<IActionResult> CreateUser(User user)
    {
        if(user == null)
        {
            return BadRequest();
        }
        user.Id = Guid.NewGuid();
        user.CreatedAt = DateTime.Now;
        user.UpdatedAt = DateTime.Now;
        
        _userRepository.Add(user);
        
        await _userRepository.SaveChangesAsync();
        return Ok(user);
    }
    
    [HttpPut("updateUser/{id:guid}")]
    public async Task<IActionResult> UpdateUser(Guid id, User user) //userden önce frombody
    {
        var existingUser = await _userRepository.GetByIdAsync(id);
        if(existingUser == null)
        {
            return NotFound("User not found");
        }
        
        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.Username = user.Username;
        existingUser.Email = user.Email;
        existingUser.Role = user.Role;
        existingUser.UpdatedAt = DateTime.Now;
        
        _userRepository.Update(existingUser);
        
        await _userRepository.SaveChangesAsync();
        return Ok(existingUser);
    }
    
    [HttpDelete("deleteUser/{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var existingUser = await _userRepository.GetByIdAsync(id);
        if(existingUser == null)
        {
            return NotFound("User not found");
        }
        
        _userRepository.Delete(existingUser);
        
        await _userRepository.SaveChangesAsync();
        return Ok();
    }
}