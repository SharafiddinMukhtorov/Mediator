using MediatR;

namespace TestProjectForPattern.Features.Category.Queries;

public record GetCategoryByIdQuery(int id) : IRequest<App.Domain.Models.Category>;
