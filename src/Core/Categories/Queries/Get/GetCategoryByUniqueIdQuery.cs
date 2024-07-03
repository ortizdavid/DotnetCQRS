using System.ComponentModel.DataAnnotations;

namespace DotnetCQRS.Core.Categories.Queries
{
    public class GetCategoryByUniqueIdQuery
    {
        [Required]
        public Guid UniqueId { get; set; }
    }
}