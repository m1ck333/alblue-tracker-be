using MediatR;

namespace AlblueMES.Modules.Production.Application.Commands.ActivateSpecialRequestType;

public record ActivateSpecialRequestTypeCommand(Guid Id) : IRequest<Unit>;
