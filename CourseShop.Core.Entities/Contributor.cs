using System;
using System.Collections.Generic;
using System.Text;

namespace CourseShop.Core.Entities
{
    public class Contributor
    {
        public int ContributorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
    }
}
