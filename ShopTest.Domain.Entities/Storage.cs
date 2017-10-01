using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopTest.Domain.Entities
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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        public Storage()
        {
        }

        /// <summary>
        /// Иницилизирует новый склад
        /// </summary>
        /// <param name="street">Улица на которой находится склад</param>
        /// <param name="phone">Номер телефона склада</param>
        public Storage(string street,string phone)
        {
            Id = Guid.NewGuid();
            Street = street;
            Phone = phone;
        }
    }
}
