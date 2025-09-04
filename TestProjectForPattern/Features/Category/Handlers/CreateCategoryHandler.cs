using App.Domain.Interfaces;
using MediatR;
using TestProjectForPattern.Features.Category.Commands;

namespace TestProjectForPattern.Features.Category.Handlers;

public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, App.Domain.Models.Category>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryHandler(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

    public async Task<App.Domain.Models.Category> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = new App.Domain.Models.Category
        {
            Name = command.name,
        };

        return await _categoryRepository.CreateCategoryAsync(category);
    }
}
