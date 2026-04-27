using AlblueMES.Modules.Tenancy.Application.DTOs;
using AlblueMES.Modules.Tenancy.Domain.Entities;
using Mapster;

namespace AlblueMES.Modules.Tenancy.Application.Mapping;

public static class TenancyMappingConfig
{
    public static void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Tenant, TenantDto>();
        config.NewConfig<TenantSettings, TenantSettingsDto>();
    }
}
