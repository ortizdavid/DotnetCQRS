using System.ComponentModel.DataAnnotations;

namespace DotnetCQRS.Models
{
    public class User : IModel
    {
        [Key]
        public int UserId { get; set; }
        public UserRole UserRole { get; set; }
        public string? UserName { get; set;}
        public string? Password { get; set; }
        public string? Image { get; set; }
        public string? Token { get; set; }
        public Guid UniqueId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}