using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopTest.Domain.Models
{
    /// <summary>
    /// Модель для связки продукт-склад
    /// </summary>
    public class ProductStorageModel
    {
        /// <summary>
        /// Id продукта
        /// </summary>
        public Guid IdProduct { get; set; }


        /// <summary>
        /// Id склада
        /// </summary>
        public Guid IdStorage { get; set; }


        /// <summary>
        /// Количество данного продукта, на данном складе
        /// </summary>
        [Range(0,Int32.MaxValue)]
        public int ProductCount { get; set; }
    }
}
