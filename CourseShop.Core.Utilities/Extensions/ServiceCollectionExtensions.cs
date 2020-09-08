using CourseShop.Core.Business.Repositories;
using CourseShop.Core.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseShop.Core.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterAppServices(this IServiceCollection services)
        {
            // Repositories
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<ICourseCategoryRepository, CourseCategoryRepository>();
            services.AddTransient<ICourseImageRepository, CourseImageRepository>();
            services.AddTransient<ICourseContributorsRepository, CourseContributorsRepository>();
            services.AddTransient<IAppCourseListRepository, AppCourseListRepository>();

            // Services
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<ICourseCategoryService, CourseCategoryService>();
            services.AddTransient<ICourseImageService, CourseImageService>();
            services.AddTransient<IAppCourseListService, AppCourseListService>();
        }
    }
}
