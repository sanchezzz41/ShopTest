using System;
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
    /// Контроллер для работы с продуктами
    /// </summary>
    [Route("Products")]
    [Authorize(Roles = nameof(RolesOptions.Admin))]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        //Добавляет продукт
        [HttpPost]
        public async Task<object> AddProduct([FromBody] ProductModel model)
        {
            return await _productService.AddAsync(model);
        }


        //Удаляет проудкт
        [HttpDelete]
        public async Task DeleteProducts([FromQuery] Guid id)
        {
            await _productService.DeleteAsync(id);
        }
    }
}
