using App.Domain.Interfaces;
using MediatR;
using System.Data;
using TestProjectForPattern.Features.Brands.Commands;

namespace TestProjectForPattern.Features.Brand.Handlers;

public class CreateBrandHandler : IRequestHandler<CreateBrandCommand, App.Domain.Models.Brand>
{
    private readonly IBrandRepository _brandRepository;

    public CreateBrandHandler(IBrandRepository brandRepository) => _brandRepository = brandRepository;

    public async Task<App.Domain.Models.Brand> Handle(CreateBrandCommand command, CancellationToken cancellationToken)
    {
        var brand = new App.Domain.Models.Brand
        {
            Name = command.name,
        };

        return await _brandRepository.CreateBrandAsync(brand);
    }
}
