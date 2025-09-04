using App.Domain.Models;
using MediatR;

namespace TestProjectForPattern.Features.Cars.Queries;

public record GetCarByIdQuery(int Id) : IRequest<Car>;
