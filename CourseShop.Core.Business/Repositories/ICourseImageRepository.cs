using CourseShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop.Core.Business.Repositories
{
    public interface ICourseImageRepository
    {
        Task<IEnumerable<CourseImage>> GetCourseImagesAsync(int courseId);
    }
}
