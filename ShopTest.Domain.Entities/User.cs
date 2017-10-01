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
        /// Все заказы данного пользователя
        /// </summary>
        public virtual List<Order> Orders { get; set; }

        public User()
        {
        }

        /// <summary>
        /// Иницилизируется новый объект пользователь
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="email"></param>
        /// <param name="phoneNumber"></param>
        public User(string userName,string email,string phoneNumber):base(userName)
        {
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
