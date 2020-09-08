using CourseShop.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseShop.Core.Entities
{
    public class AppCourseList
    {
        public int CourseId { get; set; }
        public Guid ApplicationUserId { get; set; }
        public DateTime InsertedTime { get; set; }
        public int CourseListTypeId { get; set; }

        public CourseListType CourseListType
        {
            get { return (CourseListType)CourseListTypeId; }
            set { CourseListTypeId = (int)value; }
        }
    }
}
