using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CourseShop.Core.Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace CourseShop.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IServiceProvider serviceProvider;

        public BaseController(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var courseCategoryService = (ICourseCategoryService)serviceProvider.GetService(typeof(ICourseCategoryService));
            var courseCategories = courseCategoryService.GetAllCourseCategoriesAsync().Result;

            ViewBag.CourseCategories = courseCategories;
            base.OnActionExecuting(context);
        }
    }
}
