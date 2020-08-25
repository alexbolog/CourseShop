using System;
using System.Collections.Generic;
using System.Text;

namespace CourseShop.Core.Entities
{
    public class CourseReview
    {
        public int CourseReviewId { get; set; }
        public int CourseId { get; set; }
        public int ApplicationUserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public decimal Rating { get; set; }
    }
}
