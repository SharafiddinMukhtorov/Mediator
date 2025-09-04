using MediatR;

namespace TestProjectForPattern.Features.Category.Commands;

public record UpdateCategoryCommand(int id, string name) : IRequest<App.Domain.Models.Category>;
