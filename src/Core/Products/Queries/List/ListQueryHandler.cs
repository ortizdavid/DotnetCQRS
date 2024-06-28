
using DotnetCQRS.Models;
using DotnetCQRS.Repositories;

namespace DotnetCQRS.Core.Products.Queries
{
    public class ListProductsQueryHandler : IQueryManyHandler<Product, ListProductsQuery>
    {
        private readonly ProductRepository _repository;

        public ListProductsQueryHandler(ProductRepository repository)
        {
            _repository = repository;
        }
        
        public Task<IEnumerable<Product>> Handle(ListProductsQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<int> Count()
        {
            return Task.FromResult(0);
        }
    }
}