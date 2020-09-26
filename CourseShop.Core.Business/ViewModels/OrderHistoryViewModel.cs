using CourseShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseShop.Core.Business.ViewModels
{
    public class OrderHistoryViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
    }
}
