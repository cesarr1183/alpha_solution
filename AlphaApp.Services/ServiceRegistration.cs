using AlphaApp.DataRepository;
using Microsoft.Extensions.DependencyInjection;

namespace AlphaApp.Services
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services){
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
