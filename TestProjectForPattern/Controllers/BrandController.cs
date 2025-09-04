using App.Domain.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestProjectForPattern.DTOs;
using TestProjectForPattern.Features.Brand.Commands;
using TestProjectForPattern.Features.Brand.Queries;
using TestProjectForPattern.Features.Brands.Commands;

namespace TestProjectForPattern.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrandController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public BrandController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<Brand>>> GetAllAsync()
    {
        var result = await _mediator.Send(new GetAllBrandsQuery());
        var Dtos = _mapper.Map<List<BrandDto>>(result);

        return Ok(Dtos);
    }

    [HttpGet("Id")]
    public async Task<ActionResult<Brand>> GetByIdAsync(int id)
    {
        var result = await _mediator.Send(new GetBrandByIdQuery(id));
        var Dtos = _mapper.Map<BrandDto>(result);

        return Ok(Dtos);
    }

    [HttpPost]
    public async Task<ActionResult<Brand>> CreateAsync([FromBody] CreateBrandCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<Brand>> UpdateAsynci([FromBody] UpdateBrandCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpDelete("Id")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        await _mediator.Send(new DeleteBrandCommand(id));

        return Ok();
    }
}
