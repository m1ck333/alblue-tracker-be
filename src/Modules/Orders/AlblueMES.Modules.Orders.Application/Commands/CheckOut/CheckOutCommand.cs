using AlblueMES.Modules.Orders.Application.DTOs;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.CheckOut;

public record CheckOutCommand(Guid UserId) : IRequest<WorkSessionDto>;
