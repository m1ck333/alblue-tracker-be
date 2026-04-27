using AlblueMES.Modules.Production.Domain.Enums;

namespace AlblueMES.Modules.Production.Application.DTOs;

public record ProductCategoryProcessDto(
    Guid Id,
    Guid ProcessId,
    string? ProcessCode,
    string? ProcessName,
    ComplexityType? DefaultComplexity,
    int SequenceOrder);
