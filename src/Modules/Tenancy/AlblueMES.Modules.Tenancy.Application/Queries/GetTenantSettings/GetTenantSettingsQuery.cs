using AlblueMES.Modules.Tenancy.Application.DTOs;
using MediatR;

namespace AlblueMES.Modules.Tenancy.Application.Queries.GetTenantSettings;

public record GetTenantSettingsQuery(Guid TenantId) : IRequest<TenantSettingsDto>;
