using Agenda.BackEnd.Application.Services.Commands.ContactCommands.CreateContact;
using Agenda.BackEnd.Application.Services.Queries.ContactQueries.GetContact;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AssetsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateContact")]
        public IActionResult Create(CreateContactCommand request)
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

        [HttpGet("GetContactById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetAllContactQuery query)
        {
            try
            {
                var result = await _mediator.Send(query);
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

        [HttpGet("GetAllContacts")]
        public async Task<IActionResult> GetAllAsync([FromQuery]GetAllContactQuery query)
        {
            try
            {
                var result = await _mediator.Send(query);
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

        [HttpPut("UpdateContact")]
        public IActionResult Update(UpdateContactCommand request)
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

        [HttpDelete("DeleteContact")]
        public IActionResult Delete(CreateContactCommand request)
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
    }
}
