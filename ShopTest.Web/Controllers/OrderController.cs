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
    /// Компьютер для работы с заказами
    /// </summary>
    [Route("Orders")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IOrderProductService _orderProductService;

        public OrderController(IOrderService orderService, IOrderProductService orderProductService)
        {
            _orderService = orderService;
            _orderProductService = orderProductService;
        }

        //Добавляет Заказ
        [HttpPost]
        public async Task<object> Add([FromBody] OrderModel model)
        {
            return await _orderService.AddAsync(model);
        }


        //Оплачивает(удаляет) заказ
        [HttpDelete]
        public async Task<object> Delete([FromQuery] Guid id)
        {
            return new {Sum = await _orderService.PayOrder(id)};
        }

        //Добавляет продукт в заказ
        [HttpPost("ProductToOrder")]
        public async Task Add([FromBody]OrderProductModel model)
        {
            await _orderProductService.AddAsync(model);
        }
    }
}
