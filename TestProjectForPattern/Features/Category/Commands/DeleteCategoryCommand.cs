using MediatR;

namespace TestProjectForPattern.Features.Category.Commands;

public record DeleteCategoryCommand(int id) : IRequest;
