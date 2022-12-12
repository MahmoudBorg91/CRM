
using System.ComponentModel.DataAnnotations;


namespace GSI_Internal.Models.Api.ModelView.AuthViewModel
{
    public class ChangePasswordModelView
    {
        [Display(Name = "Password")]
        [Required(ErrorMessage = "كلمة السر مطلوبة ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "تأكيد كلمة السر مطلوب ")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "كلمة المرور وكلمة المرور التأكيدية غير متطابقتين.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "الأيميل")]
        [Required(ErrorMessage = "الأيميل مطلوب ")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "الاسم بالكامل")]
        [Required(ErrorMessage = "الاسم بالكامل مطلوب ")]
        public string FullName { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
