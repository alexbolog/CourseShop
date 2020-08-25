using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseShop.Core.Business.Services;
using CourseShop.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CourseShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICourseService courseService;
        private readonly ICourseCategoryService courseCategoryService;
        private readonly IConfiguration configuration;

        public HomeController(
            ICourseService courseService, 
            ICourseCategoryService courseCategoryService,
            IConfiguration configuration)
        {
            this.courseService = courseService;
            this.courseCategoryService = courseCategoryService;
            this.configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var allCourses = await courseService.GetAllCoursesAsync();
            var groupSize = configuration.GetValue<int>("HomePage:ItemGroupSize");
            var courseCategories = await courseCategoryService.GetAllCourseCategoriesAsync();

            ViewBag.GroupedCourses = GetGroupedCourses(allCourses, groupSize);
            ViewBag.GridColumnSize = 12 / groupSize;
            ViewBag.CourseCategories = courseCategories;
            return View();
        }

        private IEnumerable<Course[]> GetGroupedCourses(IEnumerable<Course> allCourses, int groupSize)
        {
            for(var i = 0; i < allCourses.Count(); i+= groupSize)
            {
                yield return allCourses.Skip(i).Take(groupSize).ToArray();
            }
        }
    }
}
