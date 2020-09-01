using CourseShop.Core.Business.Repositories;
using CourseShop.Core.Business.ViewModels;
using CourseShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop.Core.Business.Services
{
    public interface ICourseService 
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<IEnumerable<CourseViewModel>> GetAllFullCoursesAsync();
        IEnumerable<Course> GetAllCourses();
        void AddOrUpdateCourse(Course course);
        Course GetCourseById(int courseId);
        void RemoveById(int id);
        IEnumerable<Course> GetCarouselCourses();
    }

    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseImageService courseImageService;

        public CourseService(ICourseRepository courseRepository, ICourseImageService courseImageService)
        {
            this._courseRepository = courseRepository;
            this.courseImageService = courseImageService;
        }

        public void AddOrUpdateCourse(Course course)
        {
            this._courseRepository.AddOrEditCourse(course);
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _courseRepository.GetAllCourses();
        }

        public Course GetCourseById(int courseId)
        {
            return _courseRepository.GetCourseById(courseId);
        }

        public void RemoveById(int id)
        {
            var course = GetCourseById(id);
            _courseRepository.RemoveCourse(course);
        }

        public IEnumerable<Course> GetCarouselCourses()
        {
            var courses = _courseRepository.GetAllCourses();
            return courses.Where(c => true);
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _courseRepository.GetAllCoursesAsync();
        }

        public async Task<IEnumerable<CourseViewModel>> GetAllFullCoursesAsync()
        {
            var dbCourses = await _courseRepository.GetAllCoursesAsync();
            var courses = dbCourses.Select(c => new CourseViewModel(c)).ToList();
            //var courses =  dbCourses.Select(async c =>
            //    new CourseViewModel(c, (await courseImageService.GetCourseImagesAsync(c.CourseId)).Select(img => img.Base64Image)));
            foreach (var course in courses)
            {
                var dbImages = (await courseImageService.GetCourseImagesAsync(course.CourseId)).ToList();
                course.Base64Images = dbImages.Select(img => img.Base64Image).ToList();
            }

            return courses;
        }
    }
}
