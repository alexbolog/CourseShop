using CourseShop.Core.Business.Repositories;
using CourseShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CourseShop.Core.Business.Services
{
    public interface ICourseImageService
    {
        Task<IEnumerable<CourseImage>> GetCourseImagesAsync(int courseId);
    }

    public class CourseImageService : ICourseImageService
    {
        private readonly ICourseImageRepository courseImageRepository;

        public CourseImageService(ICourseImageRepository courseImageRepository)
        {
            this.courseImageRepository = courseImageRepository;
        }

        public async Task<IEnumerable<CourseImage>> GetCourseImagesAsync(int courseId)
        {
            return await courseImageRepository.GetCourseImagesAsync(courseId);
        }
    }
}
