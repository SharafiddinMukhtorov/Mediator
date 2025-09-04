using App.Domain.Interfaces;
using MediatR;
using TestProjectForPattern.Features.Brand.Queries;

namespace TestProjectForPattern.Features.Brand.Handlers;

public class GetAllBrandsHandler : IRequestHandler<GetAllBrandsQuery, List<App.Domain.Models.Brand>>
{
    private readonly IBrandRepository _brandRepository;

    public GetAllBrandsHandler(IBrandRepository brandRepository) => _brandRepository = brandRepository;

    public async Task<List<App.Domain.Models.Brand>> Handle(GetAllBrandsQuery query, CancellationToken cancellationToken)
    {
        return await _brandRepository.GetBrandsAsync();
    }
}
