
using DotnetCQRS.Models;
using DotnetCQRS.Repositories;

namespace DotnetCQRS.Core.Products.Queries
{
    public class GetByUniqueIdHandler : IQueryOneHandler<Product, GetByUniqueIdQuery>
    {
        private readonly ProductRepository _repository;
        
        public GetByUniqueIdHandler(ProductRepository repository)
        {
            _repository = repository;
        }

        public Task<Product> Handle(GetByUniqueIdQuery query)
        {
            throw new NotImplementedException();
        }
    }
}