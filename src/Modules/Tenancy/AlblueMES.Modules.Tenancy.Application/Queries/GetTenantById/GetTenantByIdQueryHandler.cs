using AlblueMES.BuildingBlocks.Common.Exceptions;
using AlblueMES.Modules.Tenancy.Application.DTOs;
using AlblueMES.Modules.Tenancy.Domain.Repositories;
using Mapster;
using MediatR;

namespace AlblueMES.Modules.Tenancy.Application.Queries.GetTenantById;

public class GetTenantByIdQueryHandler : IRequestHandler<GetTenantByIdQuery, TenantDto>
{
    private readonly ITenantRepository _tenantRepository;

    public GetTenantByIdQueryHandler(ITenantRepository tenantRepository)
    {
        _tenantRepository = tenantRepository;
    }

    public async Task<TenantDto> Handle(GetTenantByIdQuery request, CancellationToken cancellationToken)
    {
        var tenant = await _tenantRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException("Tenant", request.Id);

        return tenant.Adapt<TenantDto>();
    }
}
