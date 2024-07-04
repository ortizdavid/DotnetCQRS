using DotnetCQRS.Core.Products.Commands;
using DotnetCQRS.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsCommandController : ControllerBase
    {
        private ILogger<ProductsCommandController> _logger;
        private readonly IConfiguration _configuration;
        private readonly CreateProductHandler _createHandler;
        private readonly UpdateProductHandler _updateHandler;
        private readonly DeleteProductHandler _deleteHandler;

        public ProductsCommandController(ILogger<ProductsCommandController> logger, 
            IConfiguration configuration, 
            CreateProductHandler createHandler,
            UpdateProductHandler updateHandler, 
            DeleteProductHandler deleteHandler)
        {
            _logger = logger;
            _configuration = configuration;
            _createHandler = createHandler;
            _updateHandler = updateHandler;
            _deleteHandler = deleteHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            try
            {
                await _createHandler.Handle(command);
                var message = $"Product '{command.ProductName}' created successfully";
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
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            try
            {
                await _updateHandler.Handle(command);
                var message = $"Product '{command.ProductId}' updated";
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
        public async Task<IActionResult> DeleteProduct([FromQuery] DeleteProductCommand command)
        {
            try
            {
                await _deleteHandler.Handle(command);
                var message = $"Product '{command.ProductId}' deleted";
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
    }
}