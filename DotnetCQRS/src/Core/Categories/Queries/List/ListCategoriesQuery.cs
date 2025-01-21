using System.ComponentModel.DataAnnotations;

namespace DotnetCQRS.Core.Categories.Queries
{
    public class ListCategoriesQuery
    {
        [Required]
        public int PageIndex { get; set; } = 0;

        [Required]
        public int PageSize { get; set; } = 10;
    }
}