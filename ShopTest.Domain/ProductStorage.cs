using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopTest.Domain
{
    /// <summary>
    /// Класс соеденящий продукты и склады
    /// </summary>
    public class ProductStorage
    {
        /// <summary>
        /// Id продукта
        /// </summary>
        [ForeignKey(nameof(Product))]
        public Guid IdProduct { get; set; }

        public Product Product { get; set; }

        /// <summary>
        /// Id склада
        /// </summary>
        [ForeignKey(nameof(Storage))]
        public Guid IdStorage { get; set; }

        public Storage Storage { get; set; }

        /// <summary>
        /// Количество данного продукта, на данном складе
        /// </summary>
        public int ProductCount { get; set; }
    }
}
