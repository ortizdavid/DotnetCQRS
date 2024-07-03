using System.ComponentModel.DataAnnotations;

namespace DotnetCQRS.Core.Categories.Queries
{
    public class GetCategoryByIdQuery
    {
        [Required]
        public int CategoryId { get; set; }
    }
}