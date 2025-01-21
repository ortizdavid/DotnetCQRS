
using System.ComponentModel.DataAnnotations;
using DotnetCQRS.Core;
using DotnetCQRS.Repositories.Categories;

namespace DotnetCQRS.Core.Categories.Commands
{
    public class DeleteCategoryCommand 
    {
        [Required]
        public int CategoryId { get; set; }
    }
}