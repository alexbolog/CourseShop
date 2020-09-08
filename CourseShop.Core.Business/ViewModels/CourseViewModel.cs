using CourseShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace CourseShop.Core.Business.ViewModels
{
    public class CourseViewModel : Course
    {
        public CourseViewModel()
        {

        }

        public CourseViewModel(Course course)
        {
            this.CourseId = course.CourseId;
            this.Title = course.Title;
            this.ShortDescription = course.ShortDescription;
            this.Price = course.Price;
        }

        public CourseViewModel(Course course, IEnumerable<string> images) : this(course)
        {
            Base64Images = images.ToList();
        }

        public CourseViewModel(Course course, IEnumerable<string> images, IEnumerable<Contributor> contributors) : this(course, images)
        {
            Contributors = contributors.ToList();
        }

        public TimeSpan ActualLength { get; set; }
        public List<string> Base64Images { get; set; }
        public List<Contributor> Contributors { get; set; }
    }
}
