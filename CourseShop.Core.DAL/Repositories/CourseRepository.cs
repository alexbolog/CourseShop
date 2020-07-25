using CourseShop.Core.Business.Repositories;
using CourseShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseShop.Core.DAL.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseContext _courseContext;

        public CourseRepository(CourseContext courseContext)
        {
            this._courseContext = courseContext;
        }
        public void AddOrEditCourse(Course entity)
        {
            var dbEntity = _courseContext.Courses.FirstOrDefault(e => e.Id == entity.Id);
            if(dbEntity == null)
            {
                _courseContext.Courses.Add(entity);
            }
            else
            {
                dbEntity.Name = entity.Name;
                dbEntity.Description = entity.Description;
                dbEntity.Price = entity.Price;
            }
            _courseContext.SaveChanges();
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _courseContext.Courses.ToList();
        }

        public Course GetCourseById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveCourse(Course entity)
        {
            throw new NotImplementedException();
        }
    }
}
