using AlblueMES.BuildingBlocks.Common.Exceptions;
using AlblueMES.BuildingBlocks.Common.Interfaces;
using AlblueMES.Modules.Tenancy.Application.DTOs;
using AlblueMES.Modules.Tenancy.Domain.Repositories;
using Mapster;
using MediatR;

namespace AlblueMES.Modules.Tenancy.Application.Commands.UpdateTenant;

public class UpdateTenantCommandHandler : IRequestHandler<UpdateTenantCommand, TenantDto>
{
    private readonly ITenantRepository _tenantRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTenantCommandHandler(ITenantRepository tenantRepository, IUnitOfWork unitOfWork)
    {
        _tenantRepository = tenantRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<TenantDto> Handle(UpdateTenantCommand request, CancellationToken cancellationToken)
    {
        var tenant = await _tenantRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException("Tenant", request.Id);

        tenant.Update(request.Name, request.IsActive);

        if (request.DefaultWarningDays.HasValue && tenant.Settings is not null)
        {
            tenant.Settings.Update(
                request.DefaultWarningDays.Value,
                request.DefaultCriticalDays ?? tenant.Settings.DefaultCriticalDays,
                request.WarningColor ?? tenant.Settings.WarningColor,
                request.CriticalColor ?? tenant.Settings.CriticalColor);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return tenant.Adapt<TenantDto>();
    }
}
