using System;
using System.Collections.Generic;
using System.Text;

namespace CourseShop.Core.Entities
{
    public class CourseTag
    {
        public int CourseTagId { get; set; }
        public int CourseId { get; set; }
        public string Tag { get; set; }
    }
}
