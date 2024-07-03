
using System.ComponentModel.DataAnnotations;
using DotnetCQRS.Core;

namespace DotnetCQRS.Core.Categories.Commands
{
    public class UpdateCategoryCommand 
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage="CategoryId must be a positive integer.")]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 3, ErrorMessage = "Category name must be between 3 and 50 characters.")]
        public string? CategoryName { get; set; }

        [StringLength(150, ErrorMessage = "Description can't be longer than 150 characters.")]
        public string? Description { get; set; }
    }
}