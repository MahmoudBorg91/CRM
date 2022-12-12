using System.ComponentModel.DataAnnotations;

namespace GSI_Internal.Models.Api.ModelView.AuthViewModel
{
    public class LoginModel
    {

        [Required(ErrorMessage = "يجب أدخال البريد الالكتروني ")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "البريد الالكتروني غير صحيح")]
        public string Email { get; set; }

        [Required(ErrorMessage = "يجب أدخال كلمة السر ")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string DeviceToken { get; set; }

        public bool IsPersist { get; set; }
    }
}
