using CourseShop.Core.Business.Repositories;
using CourseShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CourseShop.Core.DAL.Repositories
{
    public class CourseImageRepository : ICourseImageRepository
    {
        private readonly CourseContext courseContext;

        public CourseImageRepository(CourseContext courseContext)
        {
            this.courseContext = courseContext;
        }

        public async Task<IEnumerable<CourseImage>> GetCourseImagesAsync(int courseId)
        {
            var courseImages = courseContext.CourseImages.Where(ci => ci.CourseId == courseId);
            if (!courseImages.Any())
            {
                var defaultImage = await courseContext.CourseImages.FirstOrDefaultAsync(ci => ci.CourseId == -1);
                defaultImage.CourseId = courseId;
                return new[] { defaultImage };
            }
            return courseImages;
        }
    }
}
