using App.Domain.Interfaces;
using MediatR;
using TestProjectForPattern.Features.Category.Commands;

namespace TestProjectForPattern.Features.Category.Handlers;

public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryHandler(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

    public async Task Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
    {
        await _categoryRepository.DeleteCategoryAsync(command.id);
    }
}
