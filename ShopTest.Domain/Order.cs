using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopTest.Domain
{
    /// <summary>
    /// Класс описывающий заказ
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Номер заказа(Id)
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Id пользователя
        /// </summary>
        [ForeignKey(nameof(User))]
        public Guid IdUser { get; set; }

        public User User { get; set; }

        /// <summary>
        /// Сумма данного заказа
        /// </summary>
        public int Sum { get; set; }

        /// <summary>
        /// Список продуктов в данном заказе
        /// </summary>
        public virtual List<OrderProduct> OrderProducts { get; set; }

    }
}
