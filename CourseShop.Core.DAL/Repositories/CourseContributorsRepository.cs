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
    public class CourseContributorsRepository : ICourseContributorsRepository
    {
        private readonly CourseContext courseContext;

        public CourseContributorsRepository(CourseContext courseContext)
        {
            this.courseContext = courseContext;
        }
        public async Task<IEnumerable<Contributor>> GetContributorsForCourseAsync(int courseId)
        {
            return await courseContext.CourseContributors
                .Where(cc => cc.CourseId == courseId)
                .Join(courseContext.Contributors, ccontr => ccontr.CourseContributorId, contr => contr.ContributorId, 
                (courseContributor, contributor) => contributor)
                .ToListAsync();
        }
    }
}
