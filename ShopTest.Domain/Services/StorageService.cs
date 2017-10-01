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
    /// Класс реализующий IStorageService
    /// </summary>
    public class StorageService : IStorageService
    {
        private readonly DatabaseContext _context;

        public StorageService(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Список складов
        /// </summary>
        public List<Storage> Storages => _context.Storages
            .Include(x => x.ProductStorages)
            .ToList();

        /// <summary>
        /// Добавление склада в бд
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> AddAsync(StorageModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException($"Ссылка на модель равняется null.");
            }

            var resultStorage = await _context.Storages.SingleOrDefaultAsync(x =>
                string.Compare(x.Street, model.Street, StringComparison.OrdinalIgnoreCase) == 0);
            if (resultStorage != null)
            {
                throw new ArgumentException($"Склад на улице{model.Street} уже существует.");
            }

            resultStorage =new Storage(model.Street,model.Phone);
            await _context.Storages.AddAsync(resultStorage);
            await _context.SaveChangesAsync();
            return resultStorage.Id;
        }

        /// <summary>
        /// Изменение склада
        /// </summary>
        /// <param name="id">Id склада, парамерты которого надо изменить</param>
        /// <param name="model">Новая модель</param>
        /// <returns></returns>
        public async Task EditAsync(Guid id, StorageModel model)
        {
            throw new ArgumentException($"Не реализовано");
        }

        /// <summary>
        /// Удаление склада по Id
        /// </summary>
        /// <param name="id">Id склада</param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            var resultStorage = await _context.Storages.SingleOrDefaultAsync(x => x.Id == id);
            if (resultStorage == null)
            {
                throw new NullReferenceException($"Склада с таким id:{id} не существует.");
            }
            _context.Storages.Remove(resultStorage);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Возваращет список всех складов
        /// </summary>
        /// <returns></returns>
        public async Task<List<Storage>> GetAsync()
        {
            return await _context.Storages
                .Include(x => x.ProductStorages)
                .ToListAsync(); 
        }
    }
}
