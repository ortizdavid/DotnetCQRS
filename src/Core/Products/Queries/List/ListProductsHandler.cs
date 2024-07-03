
using DotnetCQRS.Exceptions;
using DotnetCQRS.Helpers;
using DotnetCQRS.Models;
using DotnetCQRS.Repositories.Products;

namespace DotnetCQRS.Core.Products.Queries
{
    public class ListProductsHandler : IQueryManyHandler<Product, ListProductsQuery>
    {
        private readonly ProductQueryRepository _repository;
        private readonly IHttpContextAccessor _httpContext;

        public ListProductsHandler(ProductQueryRepository repository, IHttpContextAccessor httpContext)
        {
            _repository = repository;
            _httpContext = httpContext;
        }
        
        public async Task<Pagination<Product>> Handle(ListProductsQuery query)
        {
            if (query is null)
            {
                throw new BadRequestException("PageSize and PageIndex cannot be null");
            }
            var count = await _repository.CountAsync();
            if (count == 0)
            {
                throw new NotFoundException("No products found");
            }
            var products = await _repository.GetAllAsync(query.PageSize, query.PageIndex);
            var pagination = new Pagination<Product>(products, count, query.PageIndex, query.PageSize, _httpContext);
            return pagination;
        }
    }
}