using AlblueMES.BuildingBlocks.Common.Exceptions;
using AlblueMES.Modules.Production.Application.Interfaces;
using AlblueMES.Modules.Production.Domain.Repositories;
using MediatR;

namespace AlblueMES.Modules.Production.Application.Commands.DeactivateSpecialRequestType;

public class DeactivateSpecialRequestTypeCommandHandler : IRequestHandler<DeactivateSpecialRequestTypeCommand, Unit>
{
    private readonly ISpecialRequestTypeRepository _repository;
    private readonly IProductionUnitOfWork _unitOfWork;

    public DeactivateSpecialRequestTypeCommandHandler(ISpecialRequestTypeRepository repository, IProductionUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeactivateSpecialRequestTypeCommand request, CancellationToken cancellationToken)
    {
        var srt = await _repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException("SpecialRequestType", request.Id);

        srt.Deactivate();
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
