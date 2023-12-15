using NTierArchitecture.DataAccess.Context;
using NTierArchitecture.DataAccess.Repositories;
using NTierArchitecture.Entities.Models;

internal sealed class UserRoleRespository : Repository<UserRole>, IUserRoleRepository
{
    public UserRoleRespository(ApplicationDbContext context) : base(context)
    {
    }
}