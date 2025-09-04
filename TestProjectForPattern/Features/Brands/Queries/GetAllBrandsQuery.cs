using MediatR;

namespace TestProjectForPattern.Features.Brand.Queries;

public record GetAllBrandsQuery() : IRequest<List<App.Domain.Models.Brand>>;
