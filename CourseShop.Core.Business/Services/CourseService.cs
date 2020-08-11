using CourseShop.Core.Business.Repositories;
using CourseShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseShop.Core.Business.Services
{
    public interface ICourseService 
    {
        IEnumerable<Course> GetAllCourses();
        void AddOrUpdateCourse(Course course);
        Course GetCourseById(int courseId);
        void RemoveById(int id);
        IEnumerable<Course> GetCarouselCourses();
        IEnumerable<Course> GetCoursesByTags(IEnumerable<string> tags);
    }
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseTagRepository _courseTagRepository;

        public CourseService(ICourseRepository courseRepository, ICourseTagRepository courseTagRepository)
        {
            this._courseRepository = courseRepository;
            this._courseTagRepository = courseTagRepository;
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
            return courses.Where(c => c.IsSelectedForCarousel);
        }

        public IEnumerable<Course> GetCoursesByTags(IEnumerable<string> tags)
        {
            var dbTags = _courseTagRepository.GetExistingTags(tags.Select(t => t.ToLower()));

            foreach(var courseId in dbTags.Select(t => t.CourseId).Distinct())
            {
                yield return _courseRepository.GetCourseById(courseId);
            }
        }
    }
}
