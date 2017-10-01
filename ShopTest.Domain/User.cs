using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopTest.Domain.Entities
{
   /// <summary>
   /// Класс описывающий пользователя
   /// </summary>
    public class User: IdentityUser
    {

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name{ get; set; }


        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Все заказы данного пользователя
        /// </summary>
        public virtual List<Order> Orders { get; set; }

    }
}
