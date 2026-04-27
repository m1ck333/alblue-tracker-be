using AlblueMES.Modules.Identity.Domain.Entities;

namespace AlblueMES.Modules.Identity.Api.Requests;

public record CreateUserRequest(
    Guid TenantId,
    string Email,
    string Password,
    string FirstName,
    string LastName,
    UserRole Role,
    List<Guid>? ProcessIds);
