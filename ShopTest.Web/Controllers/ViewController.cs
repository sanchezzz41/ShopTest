using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopTest.Domain.Entities;
using ShopTest.Domain.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopTest.Web.Controllers
{
    /// <summary>
    /// Контроллер для отображения данных(можно настроить, 
    /// что бы определённые поля возвращали методы, а не все что есть в классе)
    /// </summary>
    [Route("Views")]
    [Authorize]
    public class ViewController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<User> _userManager;
        private readonly IOrderProductService _orderProductService;
        private readonly IProductService _productService;
        private readonly IStorageService _storageService;
        private readonly IProductStorageService _productStorageService;

        public ViewController(IOrderService orderService, UserManager<User> userManager, IOrderProductService orderProductService, IProductService productService, IStorageService storageService, IProductStorageService productStorageService)
        {
            _orderService = orderService;
            _userManager = userManager;
            _orderProductService = orderProductService;
            _productService = productService;
            _storageService = storageService;
            _productStorageService = productStorageService;
        }

        [HttpGet("Users")]
        public async Task<object> GetUsers()
        {
            return await _userManager.Users.ToListAsync();
        }

        [HttpGet("Products")]
        public async Task<object> GetProducts()
        {
            return await _productService.GetAsync();
        }

        [HttpGet("Orders")]
        public async Task<object> GetOrders()
        {
            return await _orderService.GetAsync();
        }

        [HttpGet("ProductStorage")]
        public async Task<object> GetProductStorage()
        {
            return await _productStorageService.GetAsync();
        }

        [HttpGet("OrderProduct")]
        public async Task<object> GetOrderProduct()
        {
            return await _orderProductService.GetAsync();
        }

        [HttpGet("Storage")]
        public async Task<object> GetStorage()
        {
            return await _storageService.GetAsync();
        }
    }
}
