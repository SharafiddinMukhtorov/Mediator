using MediatR;

namespace TestProjectForPattern.Features.Category.Queries;

public record GetAllCategoriesQuery() : IRequest<List<App.Domain.Models.Category>>;
