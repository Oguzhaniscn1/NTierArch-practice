using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NTierArchitecture.Business.Behaviors;

namespace NTierArchitecture.Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddMediatR(cfr =>
            {
                cfr.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly);//metpdları requestlere bağlamamıza olanak sağlıyor.
                cfr.AddOpenBehavior(typeof(ValidationBehaviors<,>));
            });

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            services.AddAutoMapper(typeof(DependencyInjection).Assembly);

            return services;
        }


    }
}
