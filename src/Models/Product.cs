using System.ComponentModel.DataAnnotations;

namespace DotnetCQRS.Models
{
    public class Product : IModel
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [Required]  
        public string? ProductName { get; set; }

        [Required]  
        public string? Code { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        public string? Description { get; set; }

        [Required]
        public Guid UniqueId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}