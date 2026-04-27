using AlblueMES.BuildingBlocks.Common.Exceptions;
using AlblueMES.Modules.Production.Application.DTOs;
using AlblueMES.Modules.Production.Application.Interfaces;
using AlblueMES.Modules.Production.Domain.Entities;
using AlblueMES.Modules.Production.Domain.Repositories;
using Mapster;
using MediatR;

namespace AlblueMES.Modules.Production.Application.Commands.CreateSpecialRequestType;

public class CreateSpecialRequestTypeCommandHandler : IRequestHandler<CreateSpecialRequestTypeCommand, SpecialRequestTypeDto>
{
    private readonly ISpecialRequestTypeRepository _repository;
    private readonly IProductionUnitOfWork _unitOfWork;

    public CreateSpecialRequestTypeCommandHandler(ISpecialRequestTypeRepository repository, IProductionUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<SpecialRequestTypeDto> Handle(CreateSpecialRequestTypeCommand request, CancellationToken cancellationToken)
    {
        if (await _repository.ExistsByCodeAsync(request.Code, request.TenantId, cancellationToken))
            throw new DomainException("DUPLICATE_CODE", $"Special request type with code '{request.Code}' already exists.");

        var srt = SpecialRequestType.Create(request.TenantId, request.Code, request.Name, request.Description);

        if (request.AddsProcesses?.Count > 0)
            srt.SetAddsProcesses(request.AddsProcesses.ToArray());
        if (request.RemovesProcesses?.Count > 0)
            srt.SetRemovesProcesses(request.RemovesProcesses.ToArray());
        if (request.OnlyProcesses?.Count > 0)
            srt.SetOnlyProcesses(request.OnlyProcesses.ToArray());

        await _repository.AddAsync(srt, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return srt.Adapt<SpecialRequestTypeDto>();
    }
}
