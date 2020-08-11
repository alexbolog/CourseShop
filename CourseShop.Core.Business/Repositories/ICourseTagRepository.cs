using CourseShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseShop.Core.Business.Repositories
{
    public interface ICourseTagRepository
    {
        IEnumerable<CourseTag> GetExistingTags(IEnumerable<string> tags);
    }
}
