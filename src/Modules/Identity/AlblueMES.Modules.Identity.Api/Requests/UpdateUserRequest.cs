using AlblueMES.Modules.Identity.Domain.Entities;

namespace AlblueMES.Modules.Identity.Api.Requests;

public record UpdateUserRequest(
    Guid TenantId,
    string FirstName,
    string LastName,
    UserRole Role,
    bool IsActive,
    bool CanIncludeWithdrawnInAnalysis,
    List<Guid>? ProcessIds);
