using App.Domain.Interfaces;
using MediatR;
using TestProjectForPattern.Features.Category.Queries;

namespace TestProjectForPattern.Features.Category.Handlers;

public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, List<App.Domain.Models.Category>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetAllCategoriesHandler(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

    public async Task<List<App.Domain.Models.Category>> Handle(GetAllCategoriesQuery query, CancellationToken cancellationToken)
    {
        return await _categoryRepository.GetAllCategoriesAsync();
    }
}
