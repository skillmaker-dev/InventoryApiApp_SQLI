using Application.Interfaces.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // We register our ProductRepository.
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
