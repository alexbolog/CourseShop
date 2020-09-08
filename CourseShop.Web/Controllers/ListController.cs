using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CourseShop.Core.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseShop.Web.Controllers
{
    [Authorize]
    public class ListController : BaseController
    {
        private readonly IAppCourseListService appCourseListService;

        public ListController(IServiceProvider serviceProvider, IAppCourseListService appCourseListService)
            : base(serviceProvider)
        {
            this.appCourseListService = appCourseListService;
            ViewBag.IsShoppingList = true;
            ViewBag.ListItems = new List<object>();
        }

        public async Task<IActionResult> WishList()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.IsShoppingList = false;
            ViewBag.ListItems = (await appCourseListService.GetCoursesInListForApplicationUserAsync(Guid.Parse(userId), Core.Entities.Enums.CourseListType.WishList)).ToList();
            return View("List");
        }

        public async Task<IActionResult> ShoppingCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.IsShoppingList = true;
            ViewBag.ListItems = (await appCourseListService.GetCoursesInListForApplicationUserAsync(Guid.Parse(userId), Core.Entities.Enums.CourseListType.ShoppingCart)).ToList();
            return View("List", new object());
        }
    }
}
