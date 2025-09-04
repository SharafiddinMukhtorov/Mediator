using MediatR;

namespace TestProjectForPattern.Features.Brand.Commands;

public record UpdateBrandCommand(int Id, string Name) : IRequest<App.Domain.Models.Brand>;
