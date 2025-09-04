using MediatR;

namespace TestProjectForPattern.Features.Category.Commands;

public record CreateCategoryCommand(string name) : IRequest<App.Domain.Models.Category>;
