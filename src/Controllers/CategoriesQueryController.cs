using DotnetCQRS.Core.Categories.Queries;
using DotnetCQRS.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesQueryController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ListCategoriesHandler  _list;
        private readonly GetCategoryByIdHandler  _getById;
        private readonly GetCategoryByUniqueIdHandler  _getByUniqueId;

        public CategoriesQueryController(IConfiguration configuration, ListCategoriesHandler list, 
            GetCategoryByIdHandler getById, GetCategoryByUniqueIdHandler getByUniqueId)
        {
            _configuration = configuration;
            _list = list;
            _getById = getById;
            _getByUniqueId = getByUniqueId;
        }

        [HttpGet]
        public async Task<IActionResult> ListCategories([FromQuery] ListCategoriesQuery query)
        {
            try
            {
                var categories = await _list.Handle(query);
                return Ok(categories);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("by-id")]
        public async Task<IActionResult> GetCategoryById([FromQuery] GetCategoryByIdQuery query)
        {
            try
            {
                var product = await _getById.Handle(query);
                return Ok(product);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("by-uuid")]
        public async Task<IActionResult> GetCategoryByUniqueId([FromQuery] GetCategoryByUniqueIdQuery query)
        {
            try
            {
                var product = await _getByUniqueId.Handle(query);
                return Ok(product);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}