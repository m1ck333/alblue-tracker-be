using AlblueMES.Modules.Identity.Application.DTOs;
using AlblueMES.Modules.Identity.Domain.Entities;
using MediatR;

namespace AlblueMES.Modules.Identity.Application.Commands.CreateUser;

public record CreateUserCommand(
    Guid TenantId,
    string Email,
    string Password,
    string FirstName,
    string LastName,
    UserRole Role,
    List<Guid>? ProcessIds) : IRequest<UserDto>;
