using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseShop.Core.Business.Services;
using CourseShop.Core.Business.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CourseShop.Web.Areas.Home.Controllers
{
    [Area("Home")]
    public class HomeController : Controller
    {
        private readonly ICourseService _courseService;

        public HomeController(ICourseService courseService)
        {
            this._courseService = courseService;
        }
        public IActionResult Index()
        {
            var courses = _courseService.GetAllCourses();
            var viewModel = new CourseIndexViewModel
            {
                Courses = courses
            };
            return View(viewModel);
        }
    }
}
