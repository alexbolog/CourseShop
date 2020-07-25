using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseShop.Core.Business.Services;
using CourseShop.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CourseShop.Web.Areas.Home.Controllers
{
    [Area("Home")]
    public class ManageController : Controller
    {
        private readonly ICourseService _courseService;

        public ManageController(ICourseService courseService)
        {
            this._courseService = courseService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            _courseService.AddOrUpdateCourse(course);
            return RedirectToAction("Index", "Home");
        }
    }
}
