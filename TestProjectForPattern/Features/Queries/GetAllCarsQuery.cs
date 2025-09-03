using MediatR;
using TestProjectForPattern.Aggregates;

namespace TestProjectForPattern.Features.Queries;

public record GetAllCarsQuery() : IRequest<List<Car>>;
