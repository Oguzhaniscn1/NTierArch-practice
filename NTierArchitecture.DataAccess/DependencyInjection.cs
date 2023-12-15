using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NTierArchitecture.DataAccess.Context;
using NTierArchitecture.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services,IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("SqlServer");
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddIdentityCore<AppUser>(cfr=> 
            {
                cfr.Password.RequireNonAlphanumeric = false;
            }
            ).AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<IUnitOfWork>(sv => sv.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<ICategoryRepository, CategoryRespository>();
            services.AddScoped<IProductRepository, ProductRespository>();
            services.AddScoped<IUserRoleRepository, UserRoleRespository>();

            return services;
        }
    }
}
