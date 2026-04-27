using MediatR;

namespace AlblueMES.Modules.Production.Application.Commands.ActivateProductCategory;

public record ActivateProductCategoryCommand(Guid Id) : IRequest<Unit>;
