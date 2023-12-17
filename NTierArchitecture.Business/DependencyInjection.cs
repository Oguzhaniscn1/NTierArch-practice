using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace NTierArchitecture.Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddMediatR(cfr =>
            {
                cfr.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly);//metpdları requestlere bağlamamıza olanak sağlıyor.
            });

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            return services;
        }


    }
}
