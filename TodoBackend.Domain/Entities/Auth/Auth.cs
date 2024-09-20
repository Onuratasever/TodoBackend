using TodoBackend.Domain.Entities.Common;
namespace TodoBackend.Domain.Entities.Auth;

public class Auth : BaseEntity
{
    public Guid UserId { get; set; }
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
}