using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoBackend.Application.Users.Create;
using TodoBackend.Application.Users.Delete;
using TodoBackend.Application.Users.GetAll;
using TodoBackend.Application.Users.GetById;
using TodoBackend.Application.Users.Update;
using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController: ControllerBase
{
    readonly private IUserRepository _userRepository;
    private readonly IMediator _mediator;
    public UsersController(IUserRepository userRepository, IMediator mediator)
    {
        _userRepository = userRepository;
        _mediator = mediator;
    }
    
    [HttpGet()]
    public async Task<IActionResult> GetUserById([FromQuery] GetUserByIdQueryRequest request)
    {
        var response = await _mediator.Send(request);
        if (response.user == null)
        {
            return NotFound();
        }
        return Ok(response);
    }
    
    [HttpGet("getAllUsers")]
    public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersQueryRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
    
    [HttpPost("createUser")]
    public async Task<IActionResult> CreateUser(CreateUserCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
    
    [HttpPut("updateUser")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommandRequest request)
    {
        var response = await _mediator.Send(request);
        if (response.User == null)
        {
            return NotFound();
        }
        return Ok(response);
    }
    
    [HttpDelete("deleteUser/{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var request = new DeleteUserCommandRequest { Id = id };
        var response = await _mediator.Send(request);
        if (!response.Success)
        {
            return NotFound(response.Message);
        }

        return Ok(response.Message);
    }
}