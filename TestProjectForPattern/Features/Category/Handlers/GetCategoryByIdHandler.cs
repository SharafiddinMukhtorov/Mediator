using App.Domain.Interfaces;
using MediatR;
using TestProjectForPattern.Features.Category.Queries;

namespace TestProjectForPattern.Features.Category.Handlers;

public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, App.Domain.Models.Category>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByIdHandler (ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

    public async Task<App.Domain.Models.Category> Handle(GetCategoryByIdQuery query, CancellationToken cancellationToken)
    {
        return await _categoryRepository.GetCategoryByIdAsync(query.id);
    }
}
