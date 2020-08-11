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
            this.Id = course.Id;
            this.Name = course.Name;
            this.Description = course.Description;
            this.Price = course.Price;
            this.ThumbnailPath = course.ThumbnailPath;
            this.Contributors = course.Contributors;
            this.ActualLength = TimeSpan.FromHours(course.LengthHours);
        }

        public TimeSpan ActualLength { get; set; }
    }
}
