using System.ComponentModel.DataAnnotations;
using DotnetCQRS.Helpers;

namespace DotnetCQRS.Models
{
    public class ProductImage : IModel
    {
        [Key]
        public int ImageId { get; set; }

        [Required]
        public int ProductId { get; set; }

        public string? FrontImage { get; set; }

        public string? BackImage { get; set; }

        public string? LeftImage { get; set; }

        public string? RoghtImage { get; set; }
        
        public string? UploadDir { get; set; }
        
        [Required]
        public Guid UniqueId { get; set; } = Encryption.GenerateUUID();

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}