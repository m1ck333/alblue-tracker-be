using AlblueMES.BuildingBlocks.Common.Exceptions;
using AlblueMES.Modules.Production.Application.DTOs;
using AlblueMES.Modules.Production.Application.Interfaces;
using AlblueMES.Modules.Production.Domain.Repositories;
using Mapster;
using MediatR;

namespace AlblueMES.Modules.Production.Application.Commands.UpdateSpecialRequestType;

public class UpdateSpecialRequestTypeCommandHandler : IRequestHandler<UpdateSpecialRequestTypeCommand, SpecialRequestTypeDto>
{
    private readonly ISpecialRequestTypeRepository _repository;
    private readonly IProductionUnitOfWork _unitOfWork;

    public UpdateSpecialRequestTypeCommandHandler(ISpecialRequestTypeRepository repository, IProductionUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<SpecialRequestTypeDto> Handle(UpdateSpecialRequestTypeCommand request, CancellationToken cancellationToken)
    {
        var srt = await _repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException("SpecialRequestType", request.Id);

        srt.Update(request.Name, request.Description);

        if (request.AddsProcesses != null)
            srt.SetAddsProcesses(request.AddsProcesses.ToArray());
        if (request.RemovesProcesses != null)
            srt.SetRemovesProcesses(request.RemovesProcesses.ToArray());
        if (request.OnlyProcesses != null)
            srt.SetOnlyProcesses(request.OnlyProcesses.ToArray());

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return srt.Adapt<SpecialRequestTypeDto>();
    }
}
