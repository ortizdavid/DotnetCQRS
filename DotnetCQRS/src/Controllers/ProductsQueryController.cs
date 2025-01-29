using DotnetCQRS.Core.Products.Queries;
using DotnetCQRS.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCQRS.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsQueryController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly ListProductsHandler  _list;
    private readonly GetProductByIdHandler  _getById;
    private readonly GetProductByUniqueIdHandler  _getByUniqueId;

    public ProductsQueryController(IConfiguration configuration, ListProductsHandler list, 
        GetProductByIdHandler getById, GetProductByUniqueIdHandler getByUniqueId)
    {
        _configuration = configuration;
        _list = list;
        _getById = getById;
        _getByUniqueId = getByUniqueId;
    }

    [HttpGet]
    public async Task<IActionResult> ListProducts([FromQuery] ListProductsQuery query)
    {
        try
        {
            var products = await _list.Handle(query);
            return Ok(products);
        }
        catch (BadRequestException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("by-id")]
    public async Task<IActionResult> GetProductById([FromQuery] GetProductByIdQuery query)
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
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("by-uuid")]
    public async Task<IActionResult> GetProductByUniqueId([FromQuery] GetProductByUniqueIdQuery query)
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
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}