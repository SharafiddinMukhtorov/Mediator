using App.Domain.Interfaces;
using App.Domain.Models;
using MediatR;
using TestProjectForPattern.Features.Cars.Queries;

namespace TestProjectForPattern.Features.Cars.Handlers;

public class GetCarByIdHandler : IRequestHandler<GetCarByIdQuery, Car>
{
    private readonly ICarRepository _repo;

    public GetCarByIdHandler(ICarRepository repo) => _repo = repo;

    public async Task<Car> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repo.GetCarByIdAsync(request.Id);
    }
}
