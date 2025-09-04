using App.Domain.Models;
using MediatR;

namespace TestProjectForPattern.Features.Cars.Commands;

public record CreateCarCommand(string Model, decimal Price, int BrandId, int CategoryId) : IRequest<Car>;