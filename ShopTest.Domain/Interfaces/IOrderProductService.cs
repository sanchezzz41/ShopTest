﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShopTest.Domain.Entities;
using ShopTest.Domain.Models;

namespace ShopTest.Domain.Interfaces
{
    /// <summary>
    /// Интерфесй для работы со связками продукт-заказ
    /// </summary>
    public interface IOrderProductService
    {
        /// <summary>
        /// Возвращает список связок продукты-заказы
        /// </summary>
        List<OrderProduct> OrderProducts { get; }

        /// <summary>
        /// Добавляет продукт в заказ
        /// </summary>
        /// <returns></returns>
        Task AddAsync(OrderProductModel model);

        /// <summary>
        /// Удаляет список связок
        /// </summary>
        /// <param name="idProduct"></param>
        /// <param name="idOrder"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid idProduct, Guid idOrder);

        Task<List<OrderProduct>> GetAsync();
    }
}
