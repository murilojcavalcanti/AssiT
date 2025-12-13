using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AssiT.BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /*
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
        */
    }
}
