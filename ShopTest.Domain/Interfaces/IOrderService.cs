using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShopTest.Domain.Entities;
using ShopTest.Domain.Models;

namespace ShopTest.Domain.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с заказами
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Список заказаов
        /// </summary>
        List<Order> Orders { get; }

        /// <summary>
        /// Добавление заказа в бд
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Guid> AddAsync(OrderModel model);

        /// <summary>
        /// Изменение заказа
        /// </summary>
        /// <param name="id">Id заказа, парамерты которого надо изменить</param>
        /// <param name="model">Новая модель</param>
        /// <returns></returns>
        Task EditAsync(Guid id, OrderModel model);

        /// <summary>
        /// Удаление заказа по Id
        /// </summary>
        /// <param name="id">Id заказа</param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Возваращет список всех заказов
        /// </summary>
        /// <returns></returns>
        Task<List<Order>> GetAsync();
    }
}
