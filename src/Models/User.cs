using DotnetCQRS.Helpers;

namespace DotnetCQRS.Models
{
    public class User : IModel
    {
        public int UserId { get; set; }
        public UserRole UserRole { get; set; }
        public string? UserName { get; set;}
        public string? Password { get; set; }
        public string? Image { get; set; }
        public string? Token { get; set; } = Encryption.GenerateRandomToken(30);
        public Guid UniqueId { get; set; } = Encryption.GenerateUUID();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}