using AlblueMES.Modules.Production.Application;
using AlblueMES.Modules.Production.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlblueMES.Modules.Production.Api;

public static class ProductionModuleRegistration
{
    public static IServiceCollection AddProductionModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddProductionApplication();
        services.AddProductionInfrastructure(configuration);
        return services;
    }
}
