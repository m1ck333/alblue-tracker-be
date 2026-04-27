using AlblueMES.Modules.Tenancy.Application;
using AlblueMES.Modules.Tenancy.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlblueMES.Modules.Tenancy.Api;

public static class TenancyModuleRegistration
{
    public static IServiceCollection AddTenancyModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTenancyApplication();
        services.AddTenancyInfrastructure(configuration);
        return services;
    }
}
