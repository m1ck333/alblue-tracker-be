using AlblueMES.BuildingBlocks.Common.Exceptions;
using AlblueMES.Modules.Production.Application.DTOs;
using AlblueMES.Modules.Production.Domain.Repositories;
using Mapster;
using MediatR;

namespace AlblueMES.Modules.Production.Application.Queries.GetProcessById;

public class GetProcessByIdQueryHandler : IRequestHandler<GetProcessByIdQuery, ProcessDto>
{
    private readonly IProcessRepository _processRepository;

    public GetProcessByIdQueryHandler(IProcessRepository processRepository)
    {
        _processRepository = processRepository;
    }

    public async Task<ProcessDto> Handle(GetProcessByIdQuery request, CancellationToken cancellationToken)
    {
        var process = await _processRepository.GetByIdWithSubProcessesAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException("Process", request.Id);

        return process.Adapt<ProcessDto>();
    }
}
