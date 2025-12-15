using AssiT.BackEnd.Application.Services.Commands.ContactCommands.CreateContact;
using AssiT.BackEnd.Application.Services.Queries.ContactQueries.GetContact;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AssiT.BackEnd.API.Controllers
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

        [HttpPost("CreateAsset")]
        public IActionResult Create(CreateAssetCommand request)
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

        [HttpGet("GetAssetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetAssetByIdQuery query)
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

        [HttpGet("GetAllAssets")]
        public async Task<IActionResult> GetAllAsync([FromQuery]GetAllAssetQuery query)
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
                    entites= result.Data.Item1,
                    total=result.Data.Item2 
                };
                return Ok(resultObject);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("UpdateAsset")]
        public IActionResult Update(UpdateAssetCommand request)
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

        [HttpDelete("DeleteAsset")]
        public IActionResult Delete(DeleteAssetCommand request)
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
