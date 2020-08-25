using System;
using System.Collections.Generic;
using System.Text;

namespace CourseShop.Core.Entities
{
    public class CoursePromotion
    {
        public int CoursePromotionId {get;set;}
        public int CourseId { get; set; }
        public decimal PromotionalPrice { get; set; }
        public DateTime PromotionExpireTime { get; set; }
    }
}
