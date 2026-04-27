using AlblueMES.Modules.Production.Application.DTOs;
using AlblueMES.Modules.Production.Application.Commands.CreateProductCategory;
using MediatR;

namespace AlblueMES.Modules.Production.Application.Commands.UpdateProductCategory;

public record UpdateProductCategoryCommand(
    Guid Id,
    string Name,
    string? Description,
    int? DefaultWarningDays,
    int? DefaultCriticalDays,
    List<ProcessInput>? Processes,
    List<DependencyInput>? Dependencies) : IRequest<ProductCategoryDetailDto>;
