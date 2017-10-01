using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopTest.Database;
using ShopTest.Domain.Entities;
using ShopTest.Domain.Interfaces;
using ShopTest.Domain.Models;

namespace ShopTest.Domain.Services
{
    /// <summary>
    /// Класс реализующий IProductService
    /// </summary>
    public class ProductService:IProductService
    {
        private readonly DatabaseContext _context;

        public ProductService(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Список продуктов(товаров)
        /// </summary>
        public List<Product> Products => _context.Products
            .Include(x => x.ProductOrders)
            .Include(x => x.ProductStorages)
            .ToList();

        /// <summary>
        /// Добавления нового продукта в бд
        /// </summary>
        /// <param name="model">Модель продукта</param>
        /// <returns></returns>
        public async Task<Guid> AddAsync(ProductModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException($"Ссылка на модель равняется null.");
            }
            var resultProduct = await _context.Products.SingleOrDefaultAsync(x =>
                string.Compare(x.Name, model.Name, StringComparison.OrdinalIgnoreCase) == 0);
            if (resultProduct != null)
            {
                throw new ArgumentException($"Товар с именем {model.Name} уже существует.");    
            }

            resultProduct = new Product(model.Name,model.Cost);

            await _context.Products.AddAsync(resultProduct);
            await _context.SaveChangesAsync();
            return resultProduct.Id;
        }

        /// <summary>
        /// Изменение продукта
        /// </summary>
        /// <param name="id">Id продукта, парамерты которого надо изменить</param>
        /// <param name="model">Новая модель</param>
        /// <returns></returns>
        public async Task EditAsync(Guid id, ProductModel model)
        {
            throw new ArgumentException($"Не реализовано");
        }

        /// <summary>
        /// Удаление продукта по Id
        /// </summary>
        /// <param name="id">Id продукта</param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            var resultProduct = await _context.Products.SingleOrDefaultAsync(x => x.Id == id);
            if (resultProduct == null)
            {
                throw new NullReferenceException($"Продукта с таким id:{id} не существует.");
            }
            _context.Products.Remove(resultProduct);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Возваращет все продукты
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> GetAsync()
        {
            return await _context.Products
                .Include(x => x.ProductOrders)
                .Include(x => x.ProductStorages)
                .ToListAsync(); 
        }
    }
}
