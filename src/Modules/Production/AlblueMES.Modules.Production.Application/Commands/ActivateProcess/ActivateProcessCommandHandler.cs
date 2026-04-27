using AlblueMES.BuildingBlocks.Common.Exceptions;
using AlblueMES.Modules.Production.Application.Interfaces;
using AlblueMES.Modules.Production.Domain.Repositories;
using MediatR;

namespace AlblueMES.Modules.Production.Application.Commands.ActivateProcess;

public class ActivateProcessCommandHandler : IRequestHandler<ActivateProcessCommand, Unit>
{
    private readonly IProcessRepository _processRepository;
    private readonly IProductionUnitOfWork _unitOfWork;

    public ActivateProcessCommandHandler(IProcessRepository processRepository, IProductionUnitOfWork unitOfWork)
    {
        _processRepository = processRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(ActivateProcessCommand request, CancellationToken cancellationToken)
    {
        var process = await _processRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException("Process", request.Id);

        process.Activate();
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
