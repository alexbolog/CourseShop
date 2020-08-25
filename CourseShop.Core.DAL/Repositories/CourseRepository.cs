using CourseShop.Core.Business.Repositories;
using CourseShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var dbEntity = _courseContext.Courses.FirstOrDefault(e => e.CourseId == entity.CourseId);
            if(dbEntity == null)
            {
                _courseContext.Courses.Add(entity);
            }
            else
            {
                dbEntity.Title = entity.Title;
                dbEntity.ShortDescription = entity.ShortDescription;
                dbEntity.Price = entity.Price;
            }
            _courseContext.SaveChanges();
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _courseContext.Courses.ToList();
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _courseContext.Courses.ToListAsync();
        }

        public Course GetCourseById(int id)
        {
            return _courseContext.Courses.FirstOrDefault(c => c.CourseId == id);
        }

        public void RemoveCourse(Course entity)
        {
            _courseContext.Remove(entity);
            _courseContext.SaveChanges();
        }
    }
}
