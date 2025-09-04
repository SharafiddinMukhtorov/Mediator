using App.Domain.Interfaces;
using MediatR;
using TestProjectForPattern.Features.Brand.Commands;

namespace TestProjectForPattern.Features.Brand.Handlers;

public class UpdateBrandHandler : IRequestHandler<UpdateBrandCommand, App.Domain.Models.Brand>
{
    private readonly IBrandRepository _brandRepository;

    public UpdateBrandHandler (IBrandRepository brandRepository) => _brandRepository = brandRepository;

    public async Task<App.Domain.Models.Brand> Handle(UpdateBrandCommand command, CancellationToken cancellationToken)
    {
        var brand = new App.Domain.Models.Brand
        {
            Id = command.Id,
            Name = command.Name,
        };

        return await _brandRepository.UpdateBrandAsync(brand);
    }
}
