namespace AlblueMES.Modules.Identity.Application.DTOs;

public record LoginResponseDto(
    string Token,
    string RefreshToken,
    UserDto User);
