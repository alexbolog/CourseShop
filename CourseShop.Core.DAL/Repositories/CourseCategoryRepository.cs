using CourseShop.Core.Business.Repositories;
using CourseShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop.Core.DAL.Repositories
{
    public class CourseCategoryRepository : ICourseCategoryRepository
    {
        private readonly CourseContext courseContext;

        public CourseCategoryRepository(CourseContext courseContext)
        {
            this.courseContext = courseContext;
        }
        public async Task<IEnumerable<CourseCategory>> GetAllCourseCategoriesAsync()
        {
            return await courseContext.CourseCategories.ToListAsync();
        }
    }
}
