using System;
using System.Security.Claims;
using System.Threading.Tasks;
using CourseShop.Core.Business.Services;
using CourseShop.Core.Entities.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CourseShop.Web.Controllers
{
    public class CourseController : BaseController
    {
        private readonly ICourseService courseService;
        private readonly IAppCourseListService appCourseListService;
        public CourseController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            courseService = (ICourseService)serviceProvider.GetService(typeof(ICourseService));
            appCourseListService = (IAppCourseListService)serviceProvider.GetService(typeof(IAppCourseListService));
            ViewBag.IsInShoppingCart = false;
            ViewBag.IsInWishList = false;
        }

        public async Task<IActionResult> Index(int id)
        {
            var course = await courseService.GetFullCourseByIdAsync(id);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            if (!string.IsNullOrWhiteSpace(userId))
            {
                ViewBag.IsInShoppingCart = await appCourseListService.IsInListAsync(id, userId, CourseListType.ShoppingCart);
                ViewBag.IsInWishList = await appCourseListService.IsInListAsync(id, userId, CourseListType.WishList);
                ViewBag.IsPurchased = await appCourseListService.IsPurchasedAsync(id, userId);
            }
            return View(course);
        }
        #region WishList management
        public async Task<IActionResult> AddToWishList(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await appCourseListService.AddCourseToWishListAsync(id, Guid.Parse(userId));
            ViewBag.IsInWishList = true;
            return RedirectToAction("Index", new { id });
        }

        public async Task<IActionResult> RemoveFromWishList(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await appCourseListService.RemoveCourseFromWishListAsync(id, Guid.Parse(userId));
            ViewBag.IsInWishList = true;
            return RedirectToAction("Index", new { id });
        }
        #endregion

        #region Cart management
        public async Task<IActionResult> AddToCart(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await appCourseListService.AddCourseToShoppingListAsync(id, Guid.Parse(userId));
            ViewBag.IsInShoppingCart = true;
            return RedirectToAction("Index", new { id });
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await appCourseListService.RemoveCourseFromShoppingCartAsync(id, Guid.Parse(userId));
            ViewBag.IsInShoppingCart = true;
            return RedirectToAction("Index", new { id });
        }
        #endregion
    }
}
