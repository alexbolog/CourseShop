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
        Task<CourseViewModel> GetFullCourseByIdAsync(int courseId);
        IEnumerable<Course> GetAllCourses();
        void AddOrUpdateCourse(Course course);
        Course GetCourseById(int courseId);
        Task<Course> GetCourseByIdAsync(int courseId);
        void RemoveById(int id);
        IEnumerable<Course> GetCarouselCourses();
    }

    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;
        private readonly ICourseImageService courseImageService;
        private readonly ICourseContributorsRepository courseContributorsRepository;

        public CourseService(ICourseRepository courseRepository, ICourseImageService courseImageService, ICourseContributorsRepository courseContributorsRepository)
        {
            this.courseRepository = courseRepository;
            this.courseImageService = courseImageService;
            this.courseContributorsRepository = courseContributorsRepository;
        }

        public void AddOrUpdateCourse(Course course)
        {
            this.courseRepository.AddOrEditCourse(course);
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return courseRepository.GetAllCourses();
        }

        public Course GetCourseById(int courseId)
        {
            return courseRepository.GetCourseById(courseId);
        }

        public void RemoveById(int id)
        {
            var course = GetCourseById(id);
            courseRepository.RemoveCourse(course);
        }

        public IEnumerable<Course> GetCarouselCourses()
        {
            var courses = courseRepository.GetAllCourses();
            return courses.Where(c => true);
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await courseRepository.GetAllCoursesAsync();
        }

        public async Task<IEnumerable<CourseViewModel>> GetAllFullCoursesAsync()
        {
            var dbCourses = await courseRepository.GetAllCoursesAsync();
            var courses = dbCourses.Select(c => new CourseViewModel(c)).ToList();
            
            foreach (var course in courses)
            {
                var dbImages = (await courseImageService.GetCourseImagesAsync(course.CourseId)).ToList();
                var contributors = await courseContributorsRepository.GetContributorsForCourseAsync(course.CourseId);
                course.Base64Images = dbImages.Select(img => img.Base64Image).ToList();
                course.Contributors = contributors.ToList();
            }

            return courses;
        }

        public async Task<Course> GetCourseByIdAsync(int courseId)
        {
            return await courseRepository.GetCourseByIdAsync(courseId);
        }

        public async Task<CourseViewModel> GetFullCourseByIdAsync(int courseId)
        {
            var dbCourse = await courseRepository.GetCourseByIdAsync(courseId);
            var dbImages = await courseImageService.GetCourseImagesAsync(courseId);
            var contributors = await courseContributorsRepository.GetContributorsForCourseAsync(courseId);
            return new CourseViewModel(dbCourse, dbImages.Select(img => img.Base64Image), contributors);
        }
    }
}
