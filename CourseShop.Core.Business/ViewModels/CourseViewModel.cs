using CourseShop.Core.Entities;
using System;
using System.Collections.Generic;
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
            Base64Images = images;
        }

        public TimeSpan ActualLength { get; set; }
        public IEnumerable<string> Base64Images { get; set; }
    }
}
