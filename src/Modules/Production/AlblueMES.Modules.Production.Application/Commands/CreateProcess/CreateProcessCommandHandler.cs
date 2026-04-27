using AlblueMES.BuildingBlocks.Common.Exceptions;
using AlblueMES.Modules.Production.Application.DTOs;
using AlblueMES.Modules.Production.Application.Interfaces;
using AlblueMES.Modules.Production.Domain.Entities;
using AlblueMES.Modules.Production.Domain.Repositories;
using Mapster;
using MediatR;

namespace AlblueMES.Modules.Production.Application.Commands.CreateProcess;

public class CreateProcessCommandHandler : IRequestHandler<CreateProcessCommand, ProcessDto>
{
    private readonly IProcessRepository _processRepository;
    private readonly IProductionUnitOfWork _unitOfWork;

    public CreateProcessCommandHandler(IProcessRepository processRepository, IProductionUnitOfWork unitOfWork)
    {
        _processRepository = processRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ProcessDto> Handle(CreateProcessCommand request, CancellationToken cancellationToken)
    {
        var codeExists = await _processRepository.ExistsByCodeAsync(request.Code, request.TenantId, null, cancellationToken);
        if (codeExists)
            throw new DomainException("PROCESS_CODE_EXISTS", $"A process with code '{request.Code}' already exists.");

        var process = Process.Create(request.TenantId, request.Code, request.Name, request.SequenceOrder, request.CreatedByUserId);

        if (request.SubProcesses is { Count: > 0 })
        {
            foreach (var sub in request.SubProcesses)
                process.AddSubProcess(sub.Name, sub.SequenceOrder);
        }

        await _processRepository.AddAsync(process, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return process.Adapt<ProcessDto>();
    }
}
