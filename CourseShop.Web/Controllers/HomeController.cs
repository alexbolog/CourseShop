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
    public class HomeController : BaseController
    {
        private readonly ICourseService courseService;
        private readonly IConfiguration configuration;

        public HomeController(
            IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this.courseService = (ICourseService)serviceProvider.GetService(typeof(ICourseService));
            this.configuration = (IConfiguration)serviceProvider.GetService(typeof(IConfiguration));
        }

        public async Task<IActionResult> Index()
        {
            var allCourses = (await courseService.GetAllFullCoursesAsync()).ToList();
            var groupSize = configuration.GetValue<int>("HomePage:ItemGroupSize");

            ViewBag.GroupedCourses = GetGroupedCourses(allCourses, groupSize);
            ViewBag.GridColumnSize = 12 / groupSize;

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
