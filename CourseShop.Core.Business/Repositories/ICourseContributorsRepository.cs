using CourseShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop.Core.Business.Repositories
{
    public interface ICourseContributorsRepository
    {
        Task<IEnumerable<Contributor>> GetContributorsForCourseAsync(int courseId);
    }
}
