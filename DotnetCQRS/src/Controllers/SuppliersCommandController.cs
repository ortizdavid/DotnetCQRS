using DotnetCQRS.Core.Suppliers.Commands;
using DotnetCQRS.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersCommandController : ControllerBase
    {
        private ILogger<SuppliersCommandController> _logger;
        private readonly IConfiguration _configuration;
        private readonly CreateSupplierHandler _createHandler;
        private readonly UpdateSupplierHandler _updateHandler;
        private readonly DeleteSupplierHandler _deleteHandler;

        public SuppliersCommandController(ILogger<SuppliersCommandController> logger, 
            IConfiguration configuration, 
            CreateSupplierHandler createHandler,
            UpdateSupplierHandler updateHandler, 
            DeleteSupplierHandler deleteHandler)
        {
            _logger = logger;
            _configuration = configuration;
            _createHandler = createHandler;
            _updateHandler = updateHandler;
            _deleteHandler = deleteHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplierCommand command)
        {
            try
            {
                await _createHandler.Handle(command);
                var message = $"Supplier '{command.SupplierName}' created successfully";
                _logger.LogInformation(message);
                return StatusCode(201, message);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ConflictException ex)
            {
                return Conflict(ex.Message);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSupplier([FromBody] UpdateSupplierCommand command)
        {
            try
            {
                await _updateHandler.Handle(command);
                var message = $"Supplier '{command.SupplierId}' updated";
                _logger.LogInformation(message);
                return Ok(message);
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
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSupplier([FromQuery] DeleteSupplierCommand command)
        {
            try
            {
                await _deleteHandler.Handle(command);
                var message = $"Supplier '{command.SupplierId}' deleted";
                _logger.LogInformation(message);
                return NoContent();
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
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}