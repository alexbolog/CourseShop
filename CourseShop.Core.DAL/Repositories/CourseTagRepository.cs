using CourseShop.Core.Business.Repositories;
using CourseShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseShop.Core.DAL.Repositories
{
    public class CourseTagRepository : ICourseTagRepository
    {
        private readonly CourseContext _courseContext;

        public CourseTagRepository(CourseContext courseContext)
        {
            this._courseContext = courseContext;
        }

        public IEnumerable<CourseTag> GetExistingTags(IEnumerable<string> tags)
        {
            return _courseContext.CourseTags.Where(ct => tags.Any(t => t == ct.Tag)).ToList();
        }
    }
}
