using CourseShop.Core.Business.Repositories;
using CourseShop.Core.Business.Services;
using CourseShop.Core.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CourseShop.Web.Extensions
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
