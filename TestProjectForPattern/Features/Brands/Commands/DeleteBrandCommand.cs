using MediatR;

namespace TestProjectForPattern.Features.Brand.Commands;

public record DeleteBrandCommand(int Id) : IRequest;
