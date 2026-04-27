using AlblueMES.Modules.Identity.Application.DTOs;
using MediatR;

namespace AlblueMES.Modules.Identity.Application.Commands.RefreshToken;

public record RefreshTokenCommand(string RefreshToken) : IRequest<LoginResponseDto>;
