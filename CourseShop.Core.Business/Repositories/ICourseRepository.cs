using CourseShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseShop.Core.Business.Repositories
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAllCourses();
        Course GetCourseById(int id);
        void AddOrEditCourse(Course entity);
        void RemoveCourse(Course entity);
    }
}
