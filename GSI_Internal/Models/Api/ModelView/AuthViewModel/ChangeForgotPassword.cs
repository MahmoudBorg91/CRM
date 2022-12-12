using System.ComponentModel.DataAnnotations;

namespace GSI_Internal.Models.Api.ModelView.AuthViewModel
{
    public class ChangeForgotPassword
    {

        [Required(ErrorMessage = "يجب أدخال البريد الالكتروني ")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "البريد الالكتروني غير صحيح")]
        public string Email { get; set; }

        [Display(Name = "كلمة السر")]
        [Required(ErrorMessage = "كلمة السر مطلوبة ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = " تأكيد كلمة السر")]
        [Required(ErrorMessage = "تأكيد كلمة السر مطلوب ")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "كلمة المرور وكلمة المرور التأكيدية غير متطابقتين.")]
        public string ConfirmPassword { get; set; }
    }
}
