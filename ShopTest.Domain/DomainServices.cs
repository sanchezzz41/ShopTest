using Microsoft.Extensions.DependencyInjection;
using ShopTest.Domain.Interfaces;
using ShopTest.Domain.Services;

namespace ShopTest.Domain
{
    /// <summary>
    /// Статический класс для добавления сервисов в колекцию
    /// </summary>
    public static class DomainServices
    {
        /// <summary>
        /// Метод расширения, добавляющий сервисы из domain в колекцию 
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddDomainServices(this IServiceCollection service)
        {
            service.AddScoped<IProductService, ProductService>();
            service.AddScoped<IStorageService, StorageService>();
            service.AddScoped<IProductStorageService, ProductStorageService>();
            service.AddScoped<IOrderService, OrderService>();
            service.AddScoped<IOrderProductService, OrderProductService>();

            return service;
        }
    }
}
