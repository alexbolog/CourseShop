using CourseShop.Core.Business.Repositories;
using CourseShop.Core.Entities;
using CourseShop.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop.Core.Business.Services
{
    public interface IAppCourseListService
    {
        public Task AddCourseToShoppingListAsync(int courseId, Guid applicationUserId);
        public Task AddCourseToWishListAsync(int courseId, Guid applicationUserId);

        public Task RemoveCourseFromShoppingCartAsync(int courseId, Guid applicationUserId);
        public Task RemoveCourseFromWishListAsync(int courseId, Guid applicationUserId);

        public Task<IEnumerable<Course>> GetCoursesInListForApplicationUserAsync(Guid applicationUserId, CourseListType listType);
        Task<bool> IsInListAsync(int courseId, string applicationUserId, CourseListType listType);
    }

    public class AppCourseListService : IAppCourseListService
    {
        private readonly IAppCourseListRepository appCourseListRepository;

        public AppCourseListService(IAppCourseListRepository appCourseListRepository)
        {
            this.appCourseListRepository = appCourseListRepository;
        }

        public async Task AddCourseToShoppingListAsync(int courseId, Guid applicationUserId)
        {
            await appCourseListRepository.AddCourseToListAsync(applicationUserId, courseId, CourseListType.ShoppingCart);
        }

        public async Task AddCourseToWishListAsync(int courseId, Guid applicationUserId)
        {
            await appCourseListRepository.AddCourseToListAsync(applicationUserId, courseId, CourseListType.WishList);
        }

        public async Task<IEnumerable<Course>> GetCoursesInListForApplicationUserAsync(Guid applicationUserId, CourseListType listType)
        {
            return await appCourseListRepository.GetCoursesInListForAppUserAsync(applicationUserId, listType);
        }

        public async Task<bool> IsInListAsync(int courseId, string applicationUserId, CourseListType listType)
        {
            return await appCourseListRepository.IsInListAsync(courseId, Guid.Parse(applicationUserId), listType);
        }

        public async Task RemoveCourseFromShoppingCartAsync(int courseId, Guid applicationUserId)
        {
            await appCourseListRepository.RemoveCourseFromListAsync(applicationUserId, courseId, CourseListType.ShoppingCart);
        }

        public async Task RemoveCourseFromWishListAsync(int courseId, Guid applicationUserId)
        {
            await appCourseListRepository.RemoveCourseFromListAsync(applicationUserId, courseId, CourseListType.WishList);
        }
    }
}
