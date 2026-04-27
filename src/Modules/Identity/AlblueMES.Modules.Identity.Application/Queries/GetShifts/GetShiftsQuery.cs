using AlblueMES.BuildingBlocks.Common.Pagination;
using AlblueMES.Modules.Identity.Application.DTOs;

namespace AlblueMES.Modules.Identity.Application.Queries.GetShifts;

public record GetShiftsQuery : PagedQuery<PagedResult<ShiftDto>>
{
    public Guid TenantId { get; init; }
    public bool? IsActive { get; init; }
}
