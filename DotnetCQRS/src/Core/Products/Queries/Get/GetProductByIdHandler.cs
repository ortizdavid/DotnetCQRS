
using DotnetCQRS.Exceptions;
using DotnetCQRS.Models;
using DotnetCQRS.Repositories.Products;

namespace DotnetCQRS.Core.Products.Queries;

public class GetProductByIdHandler : IQueryOneHandler<ProductData, GetProductByIdQuery>
{
    private readonly ProductQueryRepository _repository;
    
    public GetProductByIdHandler(ProductQueryRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductData> Handle(GetProductByIdQuery query)
    {
        if (query is null)
        {
            throw new BadRequestException("ProductId cannot be null");
        }
        var product = await _repository.GetDataByIdAsync(query.ProductId);
        if (product is null)
        {
            throw new NotFoundException("Product not found");
        }
        return product;
    }
}