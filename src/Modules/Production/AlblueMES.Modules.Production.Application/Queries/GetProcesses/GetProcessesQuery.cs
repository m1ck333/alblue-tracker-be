using AlblueMES.BuildingBlocks.Common.Pagination;
using AlblueMES.Modules.Production.Application.DTOs;

namespace AlblueMES.Modules.Production.Application.Queries.GetProcesses;

public record GetProcessesQuery : PagedQuery<PagedResult<ProcessDto>>
{
    public Guid TenantId { get; init; }
    public bool? IsActive { get; init; }
}
