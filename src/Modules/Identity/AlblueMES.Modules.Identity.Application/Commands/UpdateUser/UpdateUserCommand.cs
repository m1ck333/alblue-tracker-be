using AlblueMES.Modules.Identity.Application.DTOs;
using AlblueMES.Modules.Identity.Domain.Entities;
using MediatR;

namespace AlblueMES.Modules.Identity.Application.Commands.UpdateUser;

public record UpdateUserCommand(
    Guid Id,
    Guid TenantId,
    string FirstName,
    string LastName,
    UserRole Role,
    bool IsActive,
    bool CanIncludeWithdrawnInAnalysis,
    List<Guid>? ProcessIds) : IRequest<UserDto>;
