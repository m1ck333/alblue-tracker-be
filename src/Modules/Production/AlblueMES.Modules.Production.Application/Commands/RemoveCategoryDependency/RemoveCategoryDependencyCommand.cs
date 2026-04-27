using AlblueMES.Modules.Production.Application.DTOs;
using MediatR;

namespace AlblueMES.Modules.Production.Application.Commands.RemoveCategoryDependency;

public record RemoveCategoryDependencyCommand(
    Guid CategoryId,
    Guid DependencyId) : IRequest<ProductCategoryDetailDto>;
