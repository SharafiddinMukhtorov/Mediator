using App.Domain.Models;
using MediatR;

namespace TestProjectForPattern.Features.Cars.Commands;

public record UpdateCarCommand(int Id, string Model, decimal Price, int BrandId, int CategoryId) : IRequest<Car>;