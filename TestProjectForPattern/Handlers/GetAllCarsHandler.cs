using MediatR;
using System.Reflection;
using TestProjectForPattern.Aggregates;
using TestProjectForPattern.Features.Queries;

namespace TestProjectForPattern.Handlers;

public class GetAllCarsHandler : IRequestHandler<GetAllCarsQuery, List<Car>>
{
    public Task<List<Car>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
    {
        var cars = new List<Car>
        {
            new Car { Model = "Camry", Brand = "Toyota", Price = 30000 },
            new Car { Model = "Civic", Brand = "Honda", Price = 25000 },
            new Car { Model = "A4", Brand = "Audi", Price = 40000 },
            new Car { Model = "Model 3", Brand = "Tesla", Price = 45000 },
            new Car { Model = "Mustang", Brand = "Ford", Price = 50000 }
        };

        return Task.FromResult(cars);
    }
}
