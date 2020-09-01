using System;

namespace CourseShop.Core.Business.ViewModels
{
    public class AccountViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public bool IsPersistent { get; set; } // remember me
    }
}
