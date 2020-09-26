using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CourseShop.Core.Business.Services;
using CourseShop.Core.Business.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CourseShop.Web.Controllers
{
    public class OrdersController : BaseController
    {
        private IOrderService orderService;

        public OrdersController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            orderService = (IOrderService)serviceProvider.GetService(typeof(IOrderService));
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = await orderService.GetAllOrdersForUserAsync(userId);
            return View(new OrderHistoryViewModel
            {
                Orders = orders
            });
        }
    }
}
