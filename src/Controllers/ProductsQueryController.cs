using DotnetCQRS.Core;
using DotnetCQRS.Core.Products.Queries;
using DotnetCQRS.Helpers;
using DotnetCQRS.Models;
using DotnetCQRS.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsQueryController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ListProductsQueryHandler  _list;
        private readonly GetByIdHandler  _getById;
        private readonly GetByUniqueIdHandler  _getByUniqueId;
        private readonly HttpContextAccessor _httpContextAccessor;

        public ProductsQueryController(IConfiguration configuration, ListProductsQueryHandler list, 
            GetByIdHandler getById, GetByUniqueIdHandler getByUniqueId, 
            HttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _list = list;
            _getById = getById;
            _getByUniqueId = getByUniqueId;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> ListProducts([FromQuery] ListProductsQuery query)
        {
            try
            {
                var count = await _list.Count();
                if (count is 0)
                {
                    return NotFound();
                }
                var products = await _list.Handle(query);
                var paginated = new Pagination<Product>(products, count, query.PageIndex, query.PageSize, _httpContextAccessor);
                return Ok(products);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("by-id")]
        public async Task<IActionResult> GetProductById([FromQuery] GetByIdQuery query)
        {
            try
            {
                var product = await _getById.Handle(query);
                if (product is null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("by-uuid")]
        public async Task<IActionResult> GetProductByUniqueId([FromQuery] GetByUniqueIdQuery query)
        {
            try
            {
                var product = await _getByUniqueId.Handle(query);
                if (product is null)
                {
                    return NotFound();
                } 
                return Ok(product);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}