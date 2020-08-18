using CourseShop.Admin.Core.Entities;

namespace CourseShop.Core.Business.ViewModels
{
    public class AppLoginViewModel : LoginViewModel
    {
        public bool IsPersistent { get; set; } // remember me
    }
}
