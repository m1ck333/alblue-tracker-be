using MediatR;

namespace AlblueMES.Modules.Identity.Application.Commands.ResetPassword;

public record ResetPasswordCommand(
    Guid UserId,
    string NewPassword) : IRequest<Unit>;
