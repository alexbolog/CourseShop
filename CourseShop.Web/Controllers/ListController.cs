using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CourseShop.Core.Business.Services;
using CourseShop.Core.Entities.Enums;
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
            return await GetListView(userId, CourseListType.WishList);
        }

        public async Task<IActionResult> ShoppingCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await GetListView(userId, CourseListType.ShoppingCart);
        }

        public async Task<IActionResult> RemoveFromWishList(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await appCourseListService.RemoveCourseFromWishListAsync(id, Guid.Parse(userId));
            return await GetListView(userId, CourseListType.WishList);
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await appCourseListService.RemoveCourseFromShoppingCartAsync(id, Guid.Parse(userId));
            return RedirectToAction("ShoppingCart");
        }

        private async Task<IActionResult> GetListView(string userId, CourseListType courseListType)
        {
            var listItems = (await appCourseListService.GetCoursesInListForApplicationUserAsync(Guid.Parse(userId), courseListType)).ToList();
            ViewBag.IsShoppingList = courseListType == CourseListType.ShoppingCart;
            return View("List", listItems);
        }
    }
}
