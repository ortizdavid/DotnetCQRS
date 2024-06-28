using System.ComponentModel.DataAnnotations;
using DotnetCQRS.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DotnetCQRS.Models
{
    public class Category : IModel
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string? CategoryName { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public Guid UniqueId { get; set; } = Encryption.GenerateUUID();
        
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}