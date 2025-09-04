using App.Domain.Interfaces;
using App.Domain.Models;
using MediatR;
using TestProjectForPattern.Features.Cars.Commands;

namespace TestProjectForPattern.Features.Cars.Handlers;

public class CreateCarHandler : IRequestHandler<CreateCarCommand, Car>
{
    private readonly ICarRepository _repo;

    public CreateCarHandler(ICarRepository repo) => _repo = repo;

    public async Task<Car> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var car = new Car
        {
            Name = request.Model,
            Price = request.Price,
            BrandId = request.BrandId,
            CategoryId = request.CategoryId
        };

        return await _repo.CreateCarAsync(car);
    }
}
