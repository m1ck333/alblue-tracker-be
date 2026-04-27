using AlblueMES.BuildingBlocks.Common.Pagination;
using AlblueMES.Modules.Production.Application.DTOs;

namespace AlblueMES.Modules.Production.Application.Queries.GetProductCategories;

public record GetProductCategoriesQuery : PagedQuery<PagedResult<ProductCategoryDto>>
{
    public Guid TenantId { get; init; }
    public bool? IsActive { get; init; }
}
