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

        public IActionResult Search(string tags) // tag1|tag2|tag3
        {
            var splittedTags = tags.Split('|', System.StringSplitOptions.RemoveEmptyEntries);
            
            return View(new CourseIndexViewModel());
        }
    }
}
