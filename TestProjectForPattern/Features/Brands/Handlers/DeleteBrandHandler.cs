using App.Domain.Interfaces;
using MediatR;
using TestProjectForPattern.Features.Brand.Commands;

namespace TestProjectForPattern.Features.Brand.Handlers;

public class DeleteBrandHandler : IRequestHandler<DeleteBrandCommand>
{
    private readonly IBrandRepository _brandRepository;

    public DeleteBrandHandler(IBrandRepository brandRepository) => _brandRepository = brandRepository;

    public async Task Handle(DeleteBrandCommand command,CancellationToken cancellationToken)
    {
        await _brandRepository.DeleteBrandAsync(command.Id);
    }
}
