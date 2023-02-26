using Application.Interfaces.Services;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // we register our ProductService.
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
