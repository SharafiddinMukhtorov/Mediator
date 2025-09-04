using App.Domain.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestProjectForPattern.DTOs;
using TestProjectForPattern.Features.Category.Commands;
using TestProjectForPattern.Features.Category.Queries;

namespace TestProjectForPattern.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CategoryController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<Category>>> GetAllAsync()
    {
        var result = await _mediator.Send(new GetAllCategoriesQuery());
        var Dtos = _mapper.Map<List<CategoryDto>>(result);

        return Ok(Dtos);
    }

    [HttpGet("Id")]
    public async Task<ActionResult<Category>> GetByIdAsync(int id)
    {
        var result = await _mediator.Send(new GetCategoryByIdQuery(id));
        var Dtos = _mapper.Map<CategoryDto>(result);

        return result is not null ? Ok(Dtos) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<Category>> Create([FromBody] CreateCategoryCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<Category>> UpdateAsync([FromBody] UpdateCategoryCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("Id")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _mediator.Send(new DeleteCategoryCommand(id));
        return NoContent();
    }
}
