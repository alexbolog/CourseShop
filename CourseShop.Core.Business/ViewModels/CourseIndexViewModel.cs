using CourseShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseShop.Core.Business.ViewModels
{
    public class CourseIndexViewModel
    {
        public IEnumerable<Course> Courses { get; set; }
    }
}
