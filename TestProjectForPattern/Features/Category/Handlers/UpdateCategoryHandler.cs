using App.Domain.Interfaces;
using MediatR;
using TestProjectForPattern.Features.Category.Commands;

namespace TestProjectForPattern.Features.Category.Handlers;

public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, App.Domain.Models.Category>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryHandler(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

    public async Task<App.Domain.Models.Category> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = new App.Domain.Models.Category
        {
            Id = command.id,
            Name = command.name,
        };

        return await _categoryRepository.UpdateCategoryAsync(category);
    }
}
