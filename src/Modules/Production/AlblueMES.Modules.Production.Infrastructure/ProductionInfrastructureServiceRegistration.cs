using AlblueMES.Modules.Production.Application.Interfaces;
using AlblueMES.Modules.Production.Domain.Repositories;
using AlblueMES.Modules.Production.Infrastructure.Persistence;
using AlblueMES.Modules.Production.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlblueMES.Modules.Production.Infrastructure;

public static class ProductionInfrastructureServiceRegistration
{
    public static IServiceCollection AddProductionInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var dataSourceBuilder = new Npgsql.NpgsqlDataSourceBuilder(
            configuration.GetConnectionString("DefaultConnection"));
        dataSourceBuilder.EnableDynamicJson();
        var dataSource = dataSourceBuilder.Build();

        services.AddDbContext<ProductionDbContext>(options =>
        {
            options.UseNpgsql(dataSource);
            options.UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IProductionUnitOfWork>(sp => sp.GetRequiredService<ProductionDbContext>());

        services.AddScoped<IProcessRepository, ProcessRepository>();
        services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
        services.AddScoped<ISpecialRequestTypeRepository, SpecialRequestTypeRepository>();

        return services;
    }
}
