using App.Domain.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestProjectForPattern.DTOs;
using TestProjectForPattern.Features.Brand.Queries;
using TestProjectForPattern.Features.Cars.Commands;
using TestProjectForPattern.Features.Cars.Queries;

namespace TestProjectForPattern.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CarController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<Car>>> GetAllAsync()
    {
        var result = await _mediator.Send(new GetAllCarsQuery());
        var Dtos = _mapper.Map<List<CarDto>>(result);

        return Ok(Dtos);
    }

    [HttpGet("Id")]
    public async Task<ActionResult<Car>> GetByIdAsync(int id)
    {
        var result = await _mediator.Send(new GetCarByIdQuery(id));
        var Dtos = _mapper.Map<CarDto>(result);

        return result is not null ? Ok(Dtos) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<Car>> CreateAsync([FromBody] CreateCarCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<Car>> UpdateAsync([FromBody] UpdateCarCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpDelete("Id")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _mediator.Send(new DeleteCarCommand(id));
        return Ok();
    }
}
