using CourseShop.Core.Business.Repositories;
using CourseShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseShop.Core.Business.Services
{
    public interface ICourseService 
    {
        IEnumerable<Course> GetAllCourses();
        void AddOrUpdateCourse(Course course);
        Course GetCourseById(int courseId);
        void RemoveById(int id);
    }
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            this._courseRepository = courseRepository;
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
    }
}
