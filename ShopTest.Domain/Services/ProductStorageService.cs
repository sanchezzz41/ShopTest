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
    /// Реализция IProductStorageService 
    /// </summary>
    public class ProductStorageService : IProductStorageService
    {

        private readonly DatabaseContext _context;

        public ProductStorageService(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Возвращает список связок продукты-склады
        /// </summary>
        public List<ProductStorage> ProductStorages => _context.ProductStorages
            .Include(x => x.Storage)
            .Include(x => x.Product)
            .ToList();

        /// <summary>
        /// Добавляет продукт на склад(если он уже есть на складе, то прибавляет количество)
        /// </summary>
        /// <returns></returns>
        public async Task AddAsync(ProductStorageModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException($"Ссылка на модель равняется null.");
            }

            var result = await _context.ProductStorages.SingleOrDefaultAsync(x =>
                x.IdProduct == model.IdProduct && x.IdStorage == model.IdStorage);
            if (result != null)
            {
                result.ProductCount += model.ProductCount;
            }
            else
            {
                result = new ProductStorage
                {
                    IdProduct = model.IdProduct,
                    IdStorage = model.IdStorage,
                    ProductCount =model.ProductCount
                };
                await _context.ProductStorages.AddAsync(result);
            }
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Удаляет список связок
        /// </summary>
        /// <param name="idProduct"></param>
        /// <param name="idStorage"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid idProduct, Guid idStorage)
        {
            var result = await _context.ProductStorages.SingleOrDefaultAsync(x =>
                x.IdProduct == idProduct && x.IdStorage == idStorage);
            if (result == null)
            {
                throw new NullReferenceException($"Связки продукт-склад с такими id's нету.");
            }
            _context.ProductStorages.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductStorage>> GetAsync()
        {
            return await _context.ProductStorages
                .Include(x => x.Storage)
                .Include(x => x.Product)
                .ToListAsync();
        }
    }
}
