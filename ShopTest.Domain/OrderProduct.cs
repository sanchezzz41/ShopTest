using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopTest.Domain
{
    /// <summary>
    /// Класс связывающий продукты и заказы
    /// </summary>
    public class OrderProduct
    {
        /// <summary>
        /// Id продукта
        /// </summary>
        [ForeignKey(nameof(Product))]
        public Guid IdProduct { get; set; }

        public Product Product { get; set; }

        /// <summary>
        /// Id заказа
        /// </summary>
        [ForeignKey(nameof(Order))]
        public Guid IdOrder { get; set; }

        public Order Order { get; set; }

        /// <summary>
        /// Количество заказанного продукта
        /// </summary>
        public int ProductCount { get; set; }
    }
}
