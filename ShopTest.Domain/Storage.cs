using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopTest.Domain
{
    /// <summary>
    /// Класс описывающий склад
    /// </summary>
    public class Storage
    {
        /// <summary>
        /// Id хранилища
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Улица на которой расположен склад
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Номер телефона склада
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Список, показывающий что имеется на данном складе
        /// </summary>
        public virtual List<ProductStorage> ProductStorages { get; set; }
    }
}
