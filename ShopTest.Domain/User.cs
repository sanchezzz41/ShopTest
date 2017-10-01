using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ShopTest.Domain
{
   /// <summary>
   /// Класс описывающий пользователя
   /// </summary>
    public class User
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name{ get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Все заказы данного пользователя
        /// </summary>
        public virtual List<Order> Orders { get; set; }
    }
}
