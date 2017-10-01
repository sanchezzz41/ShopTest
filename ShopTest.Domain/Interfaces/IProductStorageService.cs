using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShopTest.Domain.Entities;
using ShopTest.Domain.Models;

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
        /// Добавляет продукт на склад(если он уже есть на складе, то прибавляет количество)
        /// </summary>
        /// <returns></returns>
        Task AddAsync(ProductStorageModel model);

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
