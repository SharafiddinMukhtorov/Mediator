using MediatR;

namespace TestProjectForPattern.Features.Brands.Commands;

public record CreateBrandCommand(string name) : IRequest<App.Domain.Models.Brand>;
