using System.ComponentModel.DataAnnotations;
using DotnetCQRS.Helpers;

namespace DotnetCQRS.Models
{
    public class Supplier : IModel
    {
        [Key]
        public int SupplierId { get; set; }

        [Required]
        public string? SupplierName { get; set; }

        [Required]
        public string? IdentificationNumber { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? PrimaryPhone { get; set; }

        public string? SecondaryPhone { get; set; }

        public string? Address { get; set; }
        
        [Required]
        public Guid UniqueId { get; set; } = Encryption.GenerateUUID();
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}