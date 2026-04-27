using AlblueMES.BuildingBlocks.Common.Pagination;
using AlblueMES.Modules.Tenancy.Application.DTOs;

namespace AlblueMES.Modules.Tenancy.Application.Queries.GetTenants;

public record GetTenantsQuery : PagedQuery<PagedResult<TenantDto>>
{
    public bool? IsActive { get; init; }
}
