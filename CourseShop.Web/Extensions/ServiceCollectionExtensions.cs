using CourseShop.Core.Business.FSM;
using CourseShop.Core.Business.FSM.Repositories;
using CourseShop.Core.Business.FSM.Services;
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
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IFSMRepository, FSMRepository> ();

            // Services
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<ICourseCategoryService, CourseCategoryService>();
            services.AddTransient<ICourseImageService, CourseImageService>();
            services.AddTransient<IAppCourseListService, AppCourseListService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IFSMService, FSMService>();
            services.AddTransient<IFSMManager, FSMManager>();
        }
    }
}
