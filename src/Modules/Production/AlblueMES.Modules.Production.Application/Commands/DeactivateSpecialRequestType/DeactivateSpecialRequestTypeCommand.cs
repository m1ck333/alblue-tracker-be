using MediatR;

namespace AlblueMES.Modules.Production.Application.Commands.DeactivateSpecialRequestType;

public record DeactivateSpecialRequestTypeCommand(Guid Id) : IRequest<Unit>;
