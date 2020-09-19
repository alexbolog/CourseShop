using CourseShop.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseShop.Core.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<Course> Courses { get; set; }
        public DateTime InsertedDate { get; set; }
        public string AppUserId { get; set; }
        public int OrderStatusId { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus OrderStatus
        {
            get
            {
                return (OrderStatus)OrderStatusId;
            }
            set
            {
                OrderStatusId = (int)value;
            }
        }
    }
}
