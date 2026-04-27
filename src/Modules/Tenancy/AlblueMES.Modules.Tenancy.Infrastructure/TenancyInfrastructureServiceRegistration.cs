using AlblueMES.BuildingBlocks.Common.Interfaces;
using AlblueMES.Modules.Tenancy.Domain.Repositories;
using AlblueMES.Modules.Tenancy.Infrastructure.Persistence;
using AlblueMES.Modules.Tenancy.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlblueMES.Modules.Tenancy.Infrastructure;

public static class TenancyInfrastructureServiceRegistration
{
    public static IServiceCollection AddTenancyInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TenancyDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            options.UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<TenancyDbContext>());
        services.AddScoped<ITenantRepository, TenantRepository>();

        return services;
    }
}
