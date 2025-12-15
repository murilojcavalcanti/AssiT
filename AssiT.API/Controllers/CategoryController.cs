using AssiT.BackEnd.Application.Services.Commands.CategoryCommands.CreateCategory;
using AssiT.BackEnd.Application.Services.Commands.CategoryCommands.UpdateCategory;
using AssiT.BackEnd.Application.Services.Commands.ContactCommands.CreateContact;
using AssiT.BackEnd.Application.Services.Queries.CategoryQueries.GetAllCategories;
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
        [HttpPost("CreateCategory")]
        public IActionResult Create(CreateCategoryCommand request)
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

        [HttpGet("GetCategoryById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetCategoryByIdQuery query)
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
        public async Task<IActionResult> GetAllAsync([FromQuery]GetAllCategoriesQuery query)
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
        public IActionResult Update(UpdateCategoryCommand request)
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
        public IActionResult Delete(DeleteCategoryCommand request)
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
