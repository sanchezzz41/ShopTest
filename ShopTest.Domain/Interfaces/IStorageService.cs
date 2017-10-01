using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopTest.Domain.Entities;
using ShopTest.Domain.Models;

namespace ShopTest.Domain.Interfaces
{
    /// <summary>
    /// Интерфейс для работы со складами
    /// </summary>
    public interface IStorageService
    {
        /// <summary>
        /// Список складов
        /// </summary>
        List<Storage> Storages { get; }

        /// <summary>
        /// Добавление склада в бд
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Guid> AddAsync(StorageModel model);

        /// <summary>
        /// Изменение склада
        /// </summary>
        /// <param name="id">Id склада, парамерты которого надо изменить</param>
        /// <param name="model">Новая модель</param>
        /// <returns></returns>
        Task EditAsync(Guid id, StorageModel model);

        /// <summary>
        /// Удаление склада по Id
        /// </summary>
        /// <param name="id">Id склада</param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Возваращет список всех складов
        /// </summary>
        /// <returns></returns>
        Task<List<Storage>> GetAsync();
    }
}
