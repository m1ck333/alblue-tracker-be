using AlblueMES.Modules.Identity.Domain.Entities;

namespace AlblueMES.Modules.Identity.Application.Services;

public interface IJwtTokenService
{
    string GenerateToken(User user);
    string GenerateRefreshToken();
}
