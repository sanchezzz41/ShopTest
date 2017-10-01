using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShopTest.Domain.Entities;

namespace ShopTest.Domain.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с продукт-склад
    /// </summary>
    public interface IProductStorageService
    {
        /// <summary>
        /// Возвращает список связок продукты-склады
        /// </summary>
        List<ProductStorage> ProductStorages { get; }

        /// <summary>
        /// Добавляет продукт на склад
        /// </summary>
        /// <param name="idProduct">Id продукта</param>
        /// <param name="idStorage">Id склада</param>
        /// <param name="count">Количество продуктов на складе</param>
        /// <returns></returns>
        Task AddAsync(Guid idProduct, Guid idStorage,int count);

        /// <summary>
        /// Удаляет список связок
        /// </summary>
        /// <param name="idProduct"></param>
        /// <param name="idStorage"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid idProduct, Guid idStorage);

        Task<List<ProductStorage>> GetAsync();
    }
}
