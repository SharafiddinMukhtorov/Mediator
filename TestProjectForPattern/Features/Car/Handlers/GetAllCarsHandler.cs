using App.Domain.Interfaces;
using App.Domain.Models;
using MediatR;
using TestProjectForPattern.Features.Cars.Queries;

namespace TestProjectForPattern.Features.Cars.Handlers;

public class GetAllCarsHandler : IRequestHandler<GetAllCarsQuery, List<Car>>
{
    private readonly ICarRepository _repo;

    public GetAllCarsHandler(ICarRepository repo) => _repo = repo;

    public async Task<List<Car>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
    {
        return await _repo.GetAllCarsAsync();
    }
}
