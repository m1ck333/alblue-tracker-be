using AlblueMES.Modules.Production.Application.DTOs;
using MediatR;

namespace AlblueMES.Modules.Production.Application.Commands.RemoveCategoryProcess;

public record RemoveCategoryProcessCommand(
    Guid CategoryId,
    Guid ProcessId) : IRequest<ProductCategoryDetailDto>;
