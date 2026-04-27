using MediatR;

namespace AlblueMES.Modules.Production.Application.Commands.DeactivateProductCategory;

public record DeactivateProductCategoryCommand(Guid Id) : IRequest<Unit>;
