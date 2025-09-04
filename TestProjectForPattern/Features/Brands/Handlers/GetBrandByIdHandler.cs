using App.Domain.Interfaces;
using MediatR;
using TestProjectForPattern.Features.Brand.Queries;

namespace TestProjectForPattern.Features.Brands.Handlers;

public class GetBrandByIdHandler : IRequestHandler<GetBrandByIdQuery, App.Domain.Models.Brand>
{
    private readonly IBrandRepository _brandRepository;

    public GetBrandByIdHandler(IBrandRepository brandRepository) => _brandRepository = brandRepository;

    public async Task<App.Domain.Models.Brand> Handle(GetBrandByIdQuery query, CancellationToken cancellationToken)
    {
        return await _brandRepository.GetBrandByIdAsync(query.Id);
    }
}
