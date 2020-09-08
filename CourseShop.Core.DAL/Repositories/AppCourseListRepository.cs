using CourseShop.Core.Business.Repositories;
using CourseShop.Core.Entities;
using CourseShop.Core.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop.Core.DAL.Repositories
{
    public class AppCourseListRepository : IAppCourseListRepository
    {
        private readonly CourseContext courseContext;

        public AppCourseListRepository(CourseContext courseContext)
        {
            this.courseContext = courseContext;
        }

        public async Task AddCourseToListAsync(Guid applicationUserId, int courseId, CourseListType itemListType)
        {
            if (await IsInListAsync(courseId, applicationUserId, itemListType))
            {
                return;
            }
            courseContext.AppLists.Add(
                new AppCourseList
                {
                    ApplicationUserId = applicationUserId,
                    CourseId = courseId,
                    CourseListType = itemListType,
                    InsertedTime = DateTime.UtcNow
                });
            await courseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesInListForAppUserAsync(Guid applicationUserId, CourseListType listType)
        {
            return await
                courseContext.AppLists
                .Where(al => al.ApplicationUserId == applicationUserId && al.CourseListTypeId == (int)listType)
                .Join(courseContext.Courses, al => al.CourseId, c => c.CourseId, (al, c) => c)
                .ToListAsync();
        }

        public async Task<bool> IsInListAsync(int courseId, Guid applicationUserId, CourseListType listType)
        {
            return await
                courseContext.AppLists.AnyAsync(l => l.ApplicationUserId == applicationUserId && l.CourseId == courseId && l.CourseListTypeId == (int)listType);
        }

        public async Task RemoveCourseFromListAsync(Guid applicationUserId, int courseId, CourseListType listType)
        {
            var dbListItem = await courseContext.AppLists.FirstOrDefaultAsync(al => al.ApplicationUserId == applicationUserId && al.CourseId == courseId && al.CourseListTypeId == (int)listType);
            if (dbListItem != null)
            {
                courseContext.AppLists.Remove(dbListItem);
                await courseContext.SaveChangesAsync();
            }
        }
    }
}
