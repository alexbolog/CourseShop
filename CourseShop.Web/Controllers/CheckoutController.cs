using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CourseShop.Core.Business.FSM;
using CourseShop.Core.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseShop.Web.Controllers
{
    public class CheckoutController : BaseController
    {
        private IOrderService orderService;
        private IAppCourseListService appCourseListService;

        public CheckoutController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this.orderService = (IOrderService)serviceProvider.GetService(typeof(IOrderService));
            this.appCourseListService = (IAppCourseListService)serviceProvider.GetService(typeof(IAppCourseListService));
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var courses = (await appCourseListService
                .GetCoursesInListForApplicationUserAsync
                    (Guid.Parse(userId), 
                    Core.Entities.Enums.CourseListType.ShoppingCart))
                .ToList();

            await orderService.AddNewOrderAsync(userId, courses);

            //TODO: remove everything from shopping list

            return View();
        }

        public async Task<IActionResult> RunFSM()
        {
            var fsmManager = (IFSMManager)serviceProvider.GetService(typeof(IFSMManager));
            await fsmManager.Run();
            return View("Index");
        }
    }
}
