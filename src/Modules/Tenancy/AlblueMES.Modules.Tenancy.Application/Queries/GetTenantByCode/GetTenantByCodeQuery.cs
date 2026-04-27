using AlblueMES.Modules.Tenancy.Application.DTOs;
using MediatR;

namespace AlblueMES.Modules.Tenancy.Application.Queries.GetTenantByCode;

public record GetTenantByCodeQuery(string Code) : IRequest<TenantDto?>;
