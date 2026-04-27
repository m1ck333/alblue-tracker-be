using AlblueMES.Modules.Identity.Application.DTOs;
using MediatR;

namespace AlblueMES.Modules.Identity.Application.Commands.Login;

public record LoginCommand(
    string Email,
    string Password,
    string TenantCode) : IRequest<LoginResponseDto>;
