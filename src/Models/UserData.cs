namespace DotnetCQRS.Models
{
    public class UserData : IModel
    {
        public int UserId { get; }
        public Guid UniqueId { get; set; }
        public string? UserName { get; }
        public string? Password { get; }
        public string? Image { get; }
        public string? Token { get; } 
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; } 
        public UserRole RoleId { get; }
        public string? RoleName { get; }
    }
}
