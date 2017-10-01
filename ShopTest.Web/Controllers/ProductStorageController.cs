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
    /// <summary>
    /// Контроллер для работы со связкой продукт-склад
    /// </summary>
    [Route("ProductStorages")]
    [Authorize(Roles = nameof(RolesOptions.Admin))]
    public class ProductStorageController : Controller
    {
        private readonly IProductStorageService _productStorageService;

        public ProductStorageController(IProductStorageService productStorageService)
        {
            _productStorageService = productStorageService;
        }

        //Добавляет 
        [HttpPost]
        public async Task Add([FromBody] ProductStorageModel model)
        {
             await _productStorageService.AddAsync(model);
        }

        //Получает список
        [HttpGet]
        public async Task<object> Get()
        {
            return await _productStorageService.GetAsync();
        }

        //Удаляет
        [HttpDelete]
        public async Task Delete([FromQuery]Guid idProduct,[FromQuery]Guid idStorage)
        {
            await _productStorageService.DeleteAsync(idProduct,idStorage);
        }
    }
}
