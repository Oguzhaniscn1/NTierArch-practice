using NTierArchitecture.DataAccess.Context;
using NTierArchitecture.DataAccess.Repositories;
using NTierArchitecture.Entities.Models;

internal sealed class CategoryRespository : Repository<Category>, ICategoryRepository
{
    public CategoryRespository(ApplicationDbContext context) : base(context)
    {
    }
}
