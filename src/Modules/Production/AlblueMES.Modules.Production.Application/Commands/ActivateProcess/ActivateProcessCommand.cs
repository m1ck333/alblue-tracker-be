using MediatR;

namespace AlblueMES.Modules.Production.Application.Commands.ActivateProcess;

public record ActivateProcessCommand(Guid Id) : IRequest<Unit>;
