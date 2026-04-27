using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.PauseWork;

public record PauseWorkCommand(Guid UserId) : IRequest<Unit>;
