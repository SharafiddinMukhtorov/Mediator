using App.Domain.Interfaces;
using MediatR;
using TestProjectForPattern.Features.Cars.Commands;

namespace TestProjectForPattern.Features.Cars.Handlers;

public class DeleteCarHandler : IRequestHandler<DeleteCarCommand>
{
    private readonly ICarRepository _repo;

    public DeleteCarHandler(ICarRepository repo) => _repo = repo;

    public async Task Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        await _repo.DeleteCarAsync(request.Id);
    }
}
