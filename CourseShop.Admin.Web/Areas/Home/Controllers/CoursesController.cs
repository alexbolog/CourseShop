using CourseShop.Core.Business.Services;
using CourseShop.Core.Business.ViewModels;
using CourseShop.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CourseShop.Admin.Web.Areas.Home.Controllers
{
    [Area("Home")]
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            this._courseService = courseService;
        }
        public IActionResult Index()
        {
            var courses = _courseService.GetAllCourses();
            var courseIndexViewModel = new CourseIndexViewModel
            {
                Courses = courses
            };

            return View(courseIndexViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = _courseService.GetCourseById(id);
            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            _courseService.AddOrUpdateCourse(course);
            return RedirectToAction("Index", "Courses");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Course());
        }

        [HttpPost]
        public IActionResult Add(Course course)
        {
            _courseService.AddOrUpdateCourse(course);
            return RedirectToAction("Index", "Courses");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _courseService.RemoveById(id);
            return RedirectToAction("Index", "Courses");
        }
    }
}
