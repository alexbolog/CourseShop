using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CourseShop.Core.Business.Services;
using CourseShop.Core.Business.ViewModels;
using CourseShop.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseShop.Web.Controllers
{
    [Authorize]
    public class AccountManagementController : BaseController
    {
        private readonly IOrderService orderService;
        private readonly ICourseService courseService;
        private readonly UserManager<ApplicationUser> userManager;

        public AccountManagementController(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager) : base(serviceProvider)
        {
            orderService = (IOrderService)serviceProvider.GetService(typeof(IOrderService));
            courseService = (ICourseService)serviceProvider.GetService(typeof(ICourseService));
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Courses()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var purchasedCourses = await orderService.GetPurchasedCoursesAsync(userId);
            var viewModels = await courseService.GetFullCoursesAsync(purchasedCourses);
            return View("Courses", viewModels);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var user = await userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var viewModel = new AccountViewModel
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return View("EditProfile", viewModel);
        }
    }
}
