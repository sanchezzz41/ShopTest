using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopTest.Domain.Entities;
using ShopTest.Domain.Interfaces;
using ShopTest.Domain.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopTest.Web.Controllers
{    
    [Route("Products")]
    [Authorize(Roles = nameof(RolesOptions.Admin))]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<object> AddProduct([FromBody] ProductModel model)
        {
           return await _productService.AddAsync(model);
        }

        [HttpGet]
        public async Task<object> GetProducts()
        {
            return await _productService.GetAsync();
        }
    }
}
