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
    /// Класс реализующий IOrderService
    /// </summary>
    public class OrderService: IOrderService
    {

        private readonly DatabaseContext _context;

        public OrderService(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Список заказаов
        /// </summary>
        public List<Order> Orders => _context.Orders
            .Include(x => x.OrderProducts)
            .Include(x => x.User)
            .ToList();

        /// <summary>
        /// Добавление заказа в бд
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> AddAsync(OrderModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException($"Ссылка на модель равняется null.");
            }

            var resultOrder = new Order(model.IdUser);
            await _context.Orders.AddAsync(resultOrder);
            await _context.SaveChangesAsync();
            return resultOrder.Id;
        }

        /// <summary>
        /// Оплата(закрытие) заказа
        /// </summary>
        /// <returns></returns>
        public async Task<int> PayOrder(Guid idOrder)
        {
            var resultList = await _context.Orders
                .Include(x => x.OrderProducts)
                .Include(x => x.OrderProducts.Select(a => a.Product))
                .ToListAsync();
            var resultOrder = resultList.SingleOrDefault(x => x.Id == idOrder);
            if (resultOrder == null)
            {
                throw new NullReferenceException($"Ссылка на заказ равняется null.");
            }
            var resultSum = resultOrder.OrderProducts.Sum(x => x.ProductCount * x.Product.Cost);
            _context.Orders.Remove(resultOrder);
            return resultSum;
        }

        /// <summary>
        /// Изменение заказа
        /// </summary>
        /// <param name="id">Id заказа, парамерты которого надо изменить</param>
        /// <param name="model">Новая модель</param>
        /// <returns></returns>
        public async Task EditAsync(Guid id, OrderModel model)
        {
            throw new ArgumentException($"Не реализовано.");
        }

        ///// <summary>
        ///// Удаление заказа по Id
        ///// </summary>
        ///// <param name="id">Id заказа</param>
        ///// <returns></returns>
        //public async Task DeleteAsync(Guid id)
        //{
        //}

        /// <summary>
        /// Возваращет список всех заказов
        /// </summary>
        /// <returns></returns>
        public async Task<List<Order>> GetAsync()
        {
            return await _context.Orders
                .Include(x => x.OrderProducts)
                .Include(x => x.User)
                .ToListAsync(); 
        }
    }
}
