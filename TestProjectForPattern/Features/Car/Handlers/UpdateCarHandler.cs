using App.Domain.Interfaces;
using App.Domain.Models;
using MediatR;
using TestProjectForPattern.Features.Cars.Commands;

namespace TestProjectForPattern.Features.Cars.Handlers;

public class UpdateCarHandler : IRequestHandler<UpdateCarCommand, Car>
{
    private readonly ICarRepository _repo;

    public UpdateCarHandler(ICarRepository repo) => _repo = repo;

    public async Task<Car> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        var car = new Car
        {
            Id = request.Id,
            Name = request.Model,
            Price = request.Price,
            BrandId = request.BrandId,
            CategoryId = request.CategoryId
        };

        return await _repo.UpdateCarAsync(car);
    }
}
