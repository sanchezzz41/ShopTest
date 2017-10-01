using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopTest.Domain.Entities;
using ShopTest.Domain.Interfaces;
using ShopTest.Domain.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopTest.Web.Controllers
{
    [Route("Storages")]
    [Authorize(Roles = nameof(RolesOptions.Admin))]
    public class StorageController : Controller
    {
        private readonly IStorageService _storageService;

        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        //Добавляет склад
        [HttpPost]
        public async Task<object> Add([FromBody] StorageModel model)
        {
            return await _storageService.AddAsync(model);
        }

        //Получает список складов
        [HttpGet]
        public async Task<object> Get()
        {
            return await _storageService.GetAsync();
        }

        //Удаляет склад
        [HttpDelete]
        public async Task Delete([FromQuery]Guid id)
        {
            await _storageService.DeleteAsync(id);
        }
    }
}
