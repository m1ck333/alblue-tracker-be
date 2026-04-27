using MediatR;

namespace AlblueMES.Modules.Identity.Application.Commands.DeleteUser;

public record DeleteUserCommand(Guid UserId) : IRequest<Unit>;
