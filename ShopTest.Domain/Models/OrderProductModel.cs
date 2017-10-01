using System;
using System.Collections.Generic;
using System.Text;

namespace ShopTest.Domain.Models
{
    /// <summary>
    /// Модель для связки продукт-заказ
    /// </summary>
    public class OrderProductModel
    {
        /// <summary>
        /// Id продукта
        /// </summary>
        public Guid IdProduct { get; set; }

        /// <summary>
        /// Id заказа
        /// </summary>
        public Guid IdOrder { get; set; }

        /// <summary>
        /// Количество заказанного продукта
        /// </summary>
        public int ProductCount { get; set; }
    }
}
