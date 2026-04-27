using AlblueMES.BuildingBlocks.Common.Behaviors;
using AlblueMES.Modules.Production.Application.Mapping;
using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AlblueMES.Modules.Production.Application;

public static class ProductionApplicationServiceRegistration
{
    public static IServiceCollection AddProductionApplication(this IServiceCollection services)
    {
        var assembly = typeof(ProductionApplicationServiceRegistration).Assembly;

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(assembly);

        ProductionMappingConfig.Register(TypeAdapterConfig.GlobalSettings);

        return services;
    }
}
