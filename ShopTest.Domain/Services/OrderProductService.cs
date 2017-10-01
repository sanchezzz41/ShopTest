using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopTest.Database;
using ShopTest.Domain.Entities;
using ShopTest.Domain.Interfaces;
using ShopTest.Domain.Models;

namespace ShopTest.Domain.Services
{
    /// <summary>
    /// Класс реализующий IOrderProductService
    /// </summary>
    public class OrderProductService : IOrderProductService
    {
        private readonly DatabaseContext _context;

        public OrderProductService(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Возвращает список связок продукты-заказы
        /// </summary>
        public List<OrderProduct> OrderProducts => _context.OrderProducts
            .Include(x => x.Order)
            .Include(x => x.Product)
            .ToList();

        /// <summary>
        /// Добавляет продукт в заказ
        /// </summary>
        /// <returns></returns>
        public async Task AddAsync(OrderProductModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException($"Ссылка на модель равняется null.");
            }

            var result = await _context.OrderProducts.SingleOrDefaultAsync(x =>
                x.IdProduct == model.IdProduct && x.IdOrder == model.IdOrder);
            if (result != null)
            {
                result.ProductCount += model.ProductCount;
            }
            else
            {
                result = new OrderProduct
                {
                    IdProduct = model.IdProduct,
                    IdOrder = model.IdOrder,
                    ProductCount = model.ProductCount
                };
                await _context.OrderProducts.AddAsync(result);
            }
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Удаляет список связок
        /// </summary>
        /// <param name="idProduct"></param>
        /// <param name="idOrder"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid idProduct, Guid idOrder)
        {
            var result = await _context.OrderProducts.SingleOrDefaultAsync(x =>
                x.IdProduct == idProduct && x.IdOrder == idOrder);
            if (result == null)
            {
                throw new NullReferenceException($"Связки продукт-заказ с такими id's нету.");
            }
            _context.OrderProducts.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<List<OrderProduct>> GetAsync()
        {
            return await _context.OrderProducts
                .Include(x => x.Order)
                .Include(x => x.Product)
                .ToListAsync(); ;
        }
    }
}
