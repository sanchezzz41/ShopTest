using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopTest.Domain.Entities;
using ShopTest.Domain.Models;

namespace ShopTest.Domain.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с продуктами
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Список продуктов(товаров)
        /// </summary>
        List<Product> Products { get; }

        /// <summary>
        /// Добавления нового продукта в бд
        /// </summary>
        /// <param name="model">Модель продукта</param>
        /// <returns></returns>
        Task<Guid> AddAsync(ProductModel model);

        /// <summary>
        /// Изменение продукта
        /// </summary>
        /// <param name="id">Id продукта, парамерты которого надо изменить</param>
        /// <param name="model">Новая модель</param>
        /// <returns></returns>
        Task EditAsync(Guid id, ProductModel model);

        /// <summary>
        /// Удаление продукта по Id
        /// </summary>
        /// <param name="id">Id продукта</param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Возваращет все продукты
        /// </summary>
        /// <returns></returns>
        Task<List<Product>> GetAsync();

    }
}
