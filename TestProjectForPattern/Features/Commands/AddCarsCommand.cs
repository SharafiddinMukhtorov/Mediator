using MediatR;
using TestProjectForPattern.Aggregates;

namespace TestProjectForPattern.Features.Commands;

public record AddCarsCommand(string model,string brand,decimal price) : IRequest<Car>;