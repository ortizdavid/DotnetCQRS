
using DotnetCQRS.Models;
using DotnetCQRS.Repositories;

namespace DotnetCQRS.Core.Products.Queries
{
    public class GetByIdHandler : IQueryOneHandler<Product, GetByIdQuery>
    {
        private readonly ProductRepository _repository;
        
        public GetByIdHandler(ProductRepository repository)
        {
            _repository = repository;
        }

        public Task<Product> Handle(GetByIdQuery query)
        {
            throw new NotImplementedException();
        }
    }
}