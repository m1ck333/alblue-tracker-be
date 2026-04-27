using AlblueMES.Modules.Orders.Application;
using AlblueMES.Modules.Orders.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlblueMES.Modules.Orders.Api;

public static class OrdersModuleRegistration
{
    public static IServiceCollection AddOrdersModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOrdersApplication();
        services.AddOrdersInfrastructure(configuration);
        services.AddSignalR();
        return services;
    }
}
