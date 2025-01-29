using DotnetCQRS.Core.Users.Queries;
using DotnetCQRS.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersQueryController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ListUsersHandler  _list;
        private readonly GetUserByIdHandler  _getById;
        private readonly GetUserByUniqueIdHandler  _getByUniqueId;

        public UsersQueryController(IConfiguration configuration, ListUsersHandler list, 
            GetUserByIdHandler getById, GetUserByUniqueIdHandler getByUniqueId)
        {
            _configuration = configuration;
            _list = list;
            _getById = getById;
            _getByUniqueId = getByUniqueId;
        }

        [HttpGet]
        public async Task<IActionResult> ListUsers([FromQuery] ListUsersQuery query)
        {
            try
            {
                var users = await _list.Handle(query);
                return Ok(users);
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
        public async Task<IActionResult> GetUserById([FromQuery] GetUserByIdQuery query)
        {
            try
            {
                var user = await _getById.Handle(query);
                return Ok(user);
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
        public async Task<IActionResult> GetUserByUniqueId([FromQuery] GetUserByUniqueIdQuery query)
        {
            try
            {
                var user = await _getByUniqueId.Handle(query);
                return Ok(user);
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
}