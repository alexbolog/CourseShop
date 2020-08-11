using CourseShop.Core.Business.Services;
using CourseShop.Core.Business.ViewModels;
using CourseShop.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CourseShop.Web.Areas.Home.Controllers
{
    [Area("Home")]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            this._courseService = courseService;
        }
        public IActionResult Index(int courseId)
        {
            var course = _courseService.GetCourseById(courseId);
            var model = new CourseViewModel(course);
            return View(model);
        }
    }
}
