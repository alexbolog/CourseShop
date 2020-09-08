using CourseShop.Core.Entities;
using CourseShop.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop.Core.Business.Repositories
{
    public interface IAppCourseListRepository
    {
        Task AddCourseToListAsync(Guid applicationUserId, int courseId, CourseListType itemListType);
        Task<IEnumerable<Course>> GetCoursesInListForAppUserAsync(Guid applicationUserId, CourseListType listType);
        Task<bool> IsInListAsync(int courseId, Guid applicationUserId, CourseListType listType);
        Task RemoveCourseFromListAsync(Guid applicationUserId, int courseId, CourseListType listType);
    }
}
