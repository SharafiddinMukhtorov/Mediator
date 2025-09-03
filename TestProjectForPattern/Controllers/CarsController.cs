using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestProjectForPattern.Features.Commands;
using TestProjectForPattern.Features.Queries;

namespace TestProjectForPattern.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CarsController : Controller
{
    private readonly IMediator _mediator;
    public CarsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCars()
    {
        var cars = await _mediator.Send(new GetAllCarsQuery());

        return Ok(cars);
    }

    [HttpPost]
    public async Task<IActionResult> AddToCars(string model, string brand, decimal price)
    {
        var car = await _mediator.Send(new AddCarsCommand(model, brand, price));

        return Ok(car);
    }
}
