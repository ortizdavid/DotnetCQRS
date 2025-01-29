using System.ComponentModel.DataAnnotations;

namespace DotnetCQRS.Core.Products.Queries;

public class ListProductsQuery
{
    [Required]
    public int PageIndex { get; set; } = 0;

    [Required]
    public int PageSize { get; set; } = 10;
}