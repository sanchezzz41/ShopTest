using System;
using System.Collections.Generic;
using System.Text;

namespace ShopTest.Domain.Models
{
    /// <summary>
    /// Модель для заказа
    /// </summary>
    public class OrderModel
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public string IdUser { get; set; }

        /// <summary>
        /// Сумма данного заказа
        /// </summary>
        public int Sum { get; set; }
    }
}
