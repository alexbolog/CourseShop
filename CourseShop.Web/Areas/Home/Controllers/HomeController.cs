using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseShop.Core.Business.Services;
using CourseShop.Core.Business.ViewModels;
using CourseShop.Core.Entities;
using Microsoft.AspNetCore.Authorization;
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

        
        [HttpGet]
        public IActionResult Manage()
        {
            return View();
        }

        [Authorize(Roles = "administrator")]
        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            _courseService.AddOrUpdateCourse(course);
            return RedirectToAction("Index", "Home");
        }
    }
}
