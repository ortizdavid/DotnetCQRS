using DotnetCQRS.Core.Products.Commands;
using DotnetCQRS.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsCommandController : ControllerBase
    {
        private ILogger<ProductsCommandController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ProductRepository _repository;

        public ProductsCommandController(ILogger<ProductsCommandController> logger, 
            IConfiguration configuration, ProductRepository repository)
        {
            _logger = logger;
            _configuration = configuration;
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            try
            {
                return Created();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommand command)
        {
            return Ok();
        }
    }
}