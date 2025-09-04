using MediatR;

namespace TestProjectForPattern.Features.Brand.Queries;

public record GetBrandByIdQuery(int Id) : IRequest<App.Domain.Models.Brand>;
