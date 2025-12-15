using AssiT.Application.Models;
using AssiT.BackEnd.Application.Services.Commands.UserCommands.CreateUser;
using AssiT.BackEnd.Application.Services.Commands.UserCommands.DeleteUser;
using AssiT.BackEnd.Application.Services.Commands.UserCommands.LoginUser;
using AssiT.BackEnd.Application.Services.Commands.UserCommands.UpdateUser;
using AssiT.BackEnd.Application.Services.Queries.UserQueries.GetAllUsers;
using AssiT.BackEnd.Application.Services.Queries.UserQueries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AssiT.BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateUser")]
        public IActionResult Create([FromBody] CreateUserCommand request)
        {
            try
            {
                var result = _mediator.Send(request).Result;
                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand request)
        {
            try
            {
                ResultViewModel result = await _mediator.Send(request);
                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetUserByIdQuery query)
        {
            try
            {
                ResultViewModel result = await _mediator.Send(query);
                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAllUsersQuery query)
        {
            try
            {
                var result = await _mediator.Send(query);
                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }
                var resultObject = new
                {
                    entites = result.Data.Item1,
                    total = result.Data.Item2
                };
                return Ok(resultObject);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteUserCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
