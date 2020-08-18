using CourseShop.Core.Entities;
using System;
using System.Collections.Generic;

namespace CourseShop.Core.Business.ViewModels
{
    public class RegisterAccountViewModel
    {
        public RegisterAccountViewModel()
        {
            ErrorMessages = new string[0];
        }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }

        public IEnumerable<string> ErrorMessages { get; set; }

        public ApplicationUser ToApplicationUser()
        {
            return new ApplicationUser
            {
                UserName = this.UserName,
                Email = this.Email,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Address = this.Address,
                DateOfBirth = this.DateOfBirth
            };
        }
    }
}
