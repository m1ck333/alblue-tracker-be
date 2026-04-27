using AlblueMES.BuildingBlocks.Common.Pagination;
using AlblueMES.Modules.Tenancy.Application.DTOs;
using AlblueMES.Modules.Tenancy.Domain.Repositories;
using Mapster;
using MediatR;

namespace AlblueMES.Modules.Tenancy.Application.Queries.GetTenants;

public class GetTenantsQueryHandler : IRequestHandler<GetTenantsQuery, PagedResult<TenantDto>>
{
    private readonly ITenantRepository _tenantRepository;

    public GetTenantsQueryHandler(ITenantRepository tenantRepository)
    {
        _tenantRepository = tenantRepository;
    }

    public async Task<PagedResult<TenantDto>> Handle(GetTenantsQuery request, CancellationToken cancellationToken)
    {
        var result = await _tenantRepository.GetPagedAsync(
            request.IsActive, request.Search,
            request.GetCreatedFromUtc(), request.GetCreatedToUtc(),
            request.SortBy, request.IsDescending,
            request.GetPage(), request.GetPageSize(), cancellationToken);

        return result.MapItems(t => t.Adapt<TenantDto>());
    }
}
