
using DotnetCQRS.Exceptions;
using DotnetCQRS.Models;
using DotnetCQRS.Repositories.Products;

namespace DotnetCQRS.Core.Products.Queries
{
    public class GetProductByUniqueIdHandler : IQueryOneHandler<Product, GetProductByUniqueIdQuery>
    {
        private readonly ProductQueryRepository _repository;
        
        public GetProductByUniqueIdHandler(ProductQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(GetProductByUniqueIdQuery query)
        {
            if (query is null)
            {
                throw new BadRequestException("Product UniqueId cannot be null");
            }
            var product = await _repository.GetByUniqueIdAsync(query.UniqueId);
            if (product is null)
            {
                throw new NotFoundException("Product not found");
            }
            return product;
        }
    }
}