using CourseShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseShop.Core.Business.ViewModels
{
    public class CourseViewModel : Course
    {
        public CourseViewModel(Course course)
        {
            this.CourseId = course.CourseId;
            this.Title = course.Title;
            this.ShortDescription = course.ShortDescription;
            this.Price = course.Price;
        }

        public TimeSpan ActualLength { get; set; }
    }
}
