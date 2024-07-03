
using System.ComponentModel.DataAnnotations;
using DotnetCQRS.Core;
using DotnetCQRS.Repositories.Categories;

namespace DotnetCQRS.Core.Categories.Commands
{
    public class DeleteCategoryCommand 
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage="CategoryId must be a positive integer.")]
        public int CategoryId { get; set; }
    }
}