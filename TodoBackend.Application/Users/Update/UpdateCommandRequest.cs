using MediatR;
using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Application.Users.Update;

public class UpdateCommandRequest:IRequest<UpdateCommandResponse>
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
}