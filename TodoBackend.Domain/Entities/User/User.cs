using TodoBackend.Domain.Entities.Common;

namespace TodoBackend.Domain.Entities.User
{
    public class User: BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Role { get; set; }
    }
}
