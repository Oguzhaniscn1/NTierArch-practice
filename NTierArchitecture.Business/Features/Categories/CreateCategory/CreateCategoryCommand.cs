using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Categories.CreateCategory
{
    public sealed record class CreateCategoryCommand(string Name):IRequest;//geriye ne cevap döneceğimizi belirttik yani request
}
