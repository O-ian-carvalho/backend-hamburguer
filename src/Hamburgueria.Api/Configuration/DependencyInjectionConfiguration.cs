using Hamurgueria.Business.Intefaces.RepositoryInterfaces;
using Hamurgueria.Business.Intefaces.ServicesIntefaces;
using Hamurgueria.Business.Notifications;
using Hamurgueria.Business.Services;
using Hamurgueria.Data.Context;
using Hamurgueria.Data.Repository;
using Microsoft.Extensions.DependencyInjection;


namespace Hamburgueria.Api.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICategorieRepository, CategorieRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();


            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICategorieService, CategorieService>();
            services.AddScoped<IStatusService, StatusService>();

            services.AddScoped<INotificator, Notificator>();

            return services;
        }
    }
}
