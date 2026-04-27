using MediatR;

namespace AlblueMES.Modules.Production.Application.Commands.DeactivateProcess;

public record DeactivateProcessCommand(Guid Id) : IRequest<Unit>;
