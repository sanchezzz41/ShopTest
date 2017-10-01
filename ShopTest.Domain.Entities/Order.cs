using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopTest.Domain.Entities
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
        public Guid Id { get; set; }

        /// <summary>
        /// Id пользователя
        /// </summary>
        [ForeignKey(nameof(User))]
        public string IdUser { get; set; }

        public User User { get; set; }

        /// <summary>
        /// Сумма данного заказа
        /// </summary>
        public int Sum { get; set; }

        /// <summary>
        /// Список продуктов в данном заказе
        /// </summary>
        public virtual List<OrderProduct> OrderProducts { get; set; }

        public Order()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUser">Id пользователя</param>
        /// <param name="sum">сумма заказа</param>
        public Order(string idUser, int sum = 0)
        {
            Id = Guid.NewGuid();
            IdUser = idUser;
            Sum = sum;
        }
    }
}
