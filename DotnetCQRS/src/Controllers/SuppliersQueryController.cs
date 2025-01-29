using DotnetCQRS.Core.Suppliers.Queries;
using DotnetCQRS.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCQRS.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SuppliersQueryController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly ListSuppliersHandler  _list;
    private readonly GetSupplierByIdHandler  _getById;
    private readonly GetSupplierByUniqueIdHandler  _getByUniqueId;

    public SuppliersQueryController(IConfiguration configuration, 
        ListSuppliersHandler list, 
        GetSupplierByIdHandler getById, 
        GetSupplierByUniqueIdHandler getByUniqueId)
    {
        _configuration = configuration;
        _list = list;
        _getById = getById;
        _getByUniqueId = getByUniqueId;
    }

    [HttpGet]
    public async Task<IActionResult> ListSuppliers([FromQuery] ListSuppliersQuery query)
    {
        try
        {
            var suppliers = await _list.Handle(query);
            return Ok(suppliers);
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
    public async Task<IActionResult> GetSupplierById([FromQuery] GetSupplierByIdQuery query)
    {
        try
        {
            var supplier = await _getById.Handle(query);
            return Ok(supplier);
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
    public async Task<IActionResult> GetSupplierByUniqueId([FromQuery] GetSupplierByUniqueIdQuery query)
    {
        try
        {
            var supplier = await _getByUniqueId.Handle(query);
            return Ok(supplier);
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