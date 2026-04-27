using AlblueMES.BuildingBlocks.Common.Pagination;
using AlblueMES.Modules.Production.Application.DTOs;

namespace AlblueMES.Modules.Production.Application.Queries.GetSpecialRequestTypes;

public record GetSpecialRequestTypesQuery : PagedQuery<PagedResult<SpecialRequestTypeDto>>
{
    public Guid TenantId { get; init; }
    public bool? IsActive { get; init; }
}
