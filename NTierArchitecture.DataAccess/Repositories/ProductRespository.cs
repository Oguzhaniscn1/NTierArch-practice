using NTierArchitecture.DataAccess.Context;
using NTierArchitecture.DataAccess.Repositories;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

internal sealed class ProductRespository : Repository<Product>, IProductRepository
{
    public ProductRespository(ApplicationDbContext context) : base(context)
    {
    }
}
