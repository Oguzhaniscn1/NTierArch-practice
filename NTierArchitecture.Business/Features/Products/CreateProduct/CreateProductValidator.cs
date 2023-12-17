using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Products.CreateProduct
{
    internal sealed class CreateProductValidator:AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("ürün adı boş olamaz.");
            RuleFor(p => p.Name).NotNull().WithMessage("ürün adı boş olamaz.");
            RuleFor(p => p.Name).MinimumLength(3).WithMessage("ürün adı en az 3 karakterli olmalıdır.");
            RuleFor(p => p.CategoryId).NotNull().WithMessage("kategori boş olamaz");
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("kategori boş olamaz");
        }
    }
}
