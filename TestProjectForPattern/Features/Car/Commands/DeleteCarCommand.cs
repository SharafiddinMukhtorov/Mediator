using MediatR;

namespace TestProjectForPattern.Features.Cars.Commands;
public record DeleteCarCommand(int Id) : IRequest;