using AlblueMES.Modules.Production.Application.Commands.CreateProductCategory;
using FluentValidation;

namespace AlblueMES.Modules.Production.Application.Validators;

public class CreateProductCategoryCommandValidator : AbstractValidator<CreateProductCategoryCommand>
{
    public CreateProductCategoryCommandValidator()
    {
        RuleFor(x => x.TenantId).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
    }
}
