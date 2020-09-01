using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CourseShop.Web.Controllers
{
    public class CourseController : BaseController
    {
        public CourseController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public IActionResult Index(int id)
        {
            ViewBag.CourseId = id;
            return View();
        }
    }
}
