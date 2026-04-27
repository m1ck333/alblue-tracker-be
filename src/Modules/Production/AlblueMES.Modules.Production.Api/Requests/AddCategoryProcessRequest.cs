using AlblueMES.Modules.Production.Domain.Enums;

namespace AlblueMES.Modules.Production.Api.Requests;

public record AddCategoryProcessRequest(
    Guid ProcessId,
    int SequenceOrder,
    ComplexityType? DefaultComplexity);
