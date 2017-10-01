﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopTest.Domain.Entities
{
    /// <summary>
    /// Класс предоставляющий продукт
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Id  продукта
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        /// <summary>
        /// Название товара
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Цена товара за 1 штуку
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// Список, показывающий где есть данный продукт
        /// </summary>
        public virtual List<ProductStorage> ProductStorages{ get; set; }

        /// <summary>
        /// Список заказов, в которых есть данный продукт
        /// </summary>
        public virtual List<OrderProduct> ProductOrders { get; set; }
    }
}