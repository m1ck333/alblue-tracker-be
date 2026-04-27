using AlblueMES.Modules.Production.Application.DTOs;
using MediatR;

namespace AlblueMES.Modules.Production.Application.Commands.UpdateSpecialRequestType;

public record UpdateSpecialRequestTypeCommand(
    Guid Id,
    string Name,
    string? Description,
    List<Guid>? AddsProcesses,
    List<Guid>? RemovesProcesses,
    List<Guid>? OnlyProcesses) : IRequest<SpecialRequestTypeDto>;
