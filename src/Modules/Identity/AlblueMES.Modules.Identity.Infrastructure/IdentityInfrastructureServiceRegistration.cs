using AlblueMES.Modules.Identity.Application.Interfaces;
using AlblueMES.Modules.Identity.Application.Services;
using AlblueMES.Modules.Identity.Domain.Repositories;
using AlblueMES.Modules.Identity.Infrastructure.Persistence;
using AlblueMES.Modules.Identity.Infrastructure.Repositories;
using AlblueMES.Modules.Identity.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlblueMES.Modules.Identity.Infrastructure;

public static class IdentityInfrastructureServiceRegistration
{
    public static IServiceCollection AddIdentityInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IdentityDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            options.UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IIdentityUnitOfWork>(sp => sp.GetRequiredService<IdentityDbContext>());

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IShiftRepository, ShiftRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddScoped<ITenantLookupService, TenantLookupService>();

        return services;
    }
}
