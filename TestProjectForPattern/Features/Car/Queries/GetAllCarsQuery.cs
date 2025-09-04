using App.Domain.Models;
using MediatR;

namespace TestProjectForPattern.Features.Cars.Queries;

public record GetAllCarsQuery() : IRequest<List<Car>>;
