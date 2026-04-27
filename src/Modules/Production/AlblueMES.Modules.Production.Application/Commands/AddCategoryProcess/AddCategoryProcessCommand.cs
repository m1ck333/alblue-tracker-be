using AlblueMES.Modules.Production.Application.DTOs;
using AlblueMES.Modules.Production.Domain.Enums;
using MediatR;

namespace AlblueMES.Modules.Production.Application.Commands.AddCategoryProcess;

public record AddCategoryProcessCommand(
    Guid CategoryId,
    Guid ProcessId,
    int SequenceOrder,
    ComplexityType? DefaultComplexity) : IRequest<ProductCategoryDetailDto>;
