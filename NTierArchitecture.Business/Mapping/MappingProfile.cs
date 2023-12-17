using AutoMapper;
using NTierArchitecture.Business.Features.Categories.CreateCategory;
using NTierArchitecture.Business.Features.Categories.UpdateCategory;
using NTierArchitecture.Business.Features.Products.CreateProduct;
using NTierArchitecture.Business.Features.Products.UpdateProduct;
using NTierArchitecture.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Mapping
{
    internal sealed class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
            
            
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();


        }

    }
}
