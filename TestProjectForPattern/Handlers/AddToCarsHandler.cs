using MediatR;
using TestProjectForPattern.Aggregates;
using TestProjectForPattern.Features.Commands;

namespace TestProjectForPattern.Handlers;

public class AddToCarsHandler : IRequestHandler<AddCarsCommand, Car>
{
    public Task<Car> Handle(AddCarsCommand request, CancellationToken cancellationToken)
    {
        var newCar = new Car
        {
            Model = request.model,
            Brand = request.brand,
            Price = request.price,
        };

        return Task.FromResult(newCar);
    }
}
