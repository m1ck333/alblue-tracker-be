using AlblueMES.Modules.Production.Application.DTOs;
using MediatR;

namespace AlblueMES.Modules.Production.Application.Commands.AddSubProcess;

public record AddSubProcessCommand(Guid ProcessId, string Name, int SequenceOrder) : IRequest<SubProcessDto>;
