namespace DotnetCQRS.Core.Products.Queries
{
    public class ListProductsQuery
    {
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 10;
    }
}