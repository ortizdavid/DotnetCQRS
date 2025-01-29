using DotnetCQRS.Core.Users.Commands;
using DotnetCQRS.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCQRS.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersCommandController : ControllerBase
{
    private ILogger<UsersCommandController> _logger;
    private readonly IConfiguration _configuration;
    private readonly CreateUserHandler _createHandler;
    private readonly UpdateUserHandler _updateHandler;
    private readonly DeleteUserHandler _deleteHandler;

    public UsersCommandController(ILogger<UsersCommandController> logger, 
        IConfiguration configuration, 
        CreateUserHandler createHandler,
        UpdateUserHandler updateHandler, 
        DeleteUserHandler deleteHandler)
    {
        _logger = logger;
        _configuration = configuration;
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
    {
        try
        {
            await _createHandler.Handle(command);
            var message = $"User '{command.UserName}' created successfully";
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
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
    {
        try
        {
            await _updateHandler.Handle(command);
            var message = $"User '{command.UserId}' updated";
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
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser([FromQuery] DeleteUserCommand command)
    {
        try
        {
            await _deleteHandler.Handle(command);
            var message = $"User '{command.UserId}' deleted";
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
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500, ex.Message);
        }
    }
}