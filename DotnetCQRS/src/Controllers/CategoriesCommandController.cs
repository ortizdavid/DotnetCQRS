using DotnetCQRS.Core.Categories.Commands;
using DotnetCQRS.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesCommandController : ControllerBase
    {
        private ILogger<CategoriesCommandController> _logger;
        private readonly IConfiguration _configuration;
        private readonly CreateCategoryHandler _createHandler;
        private readonly UpdateCategoryHandler _updateHandler;
        private readonly DeleteCategoryHandler _deleteHandler;

        public CategoriesCommandController(ILogger<CategoriesCommandController> logger, 
            IConfiguration configuration, 
            CreateCategoryHandler createHandler,
            UpdateCategoryHandler updateHandler, 
            DeleteCategoryHandler deleteHandler)
        {
            _logger = logger;
            _configuration = configuration;
            _createHandler = createHandler;
            _updateHandler = updateHandler;
            _deleteHandler = deleteHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            try
            {
                await _createHandler.Handle(command);
                var message = $"Category '{command.CategoryName}' created successfully";
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
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommand command)
        {
            try
            {
                await _updateHandler.Handle(command);
                var message = $"Category '{command.CategoryId}' updated";
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
        public async Task<IActionResult> DeleteCategory([FromQuery] DeleteCategoryCommand command)
        {
            try
            {
                await _deleteHandler.Handle(command);
                var message = $"Category '{command.CategoryId}' deleted";
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