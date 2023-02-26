namespace InventoryApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            // Add services for controllers
            services.AddControllers();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            return services;
        }
    }
}
