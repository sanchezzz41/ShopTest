namespace ShopTest.Domain.Models
{
    /// <summary>
    /// Модель для продукта(Товара)
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Название товара
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Цена товара за 1 штуку
        /// </summary>
        public int Cost { get; set; }

    }
}
