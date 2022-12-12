
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GSI_Internal.Models.Api.ModelView.AuthViewModel
{
    public class UpdateAdmin
    {
        [StringLength(50), MinLength(5)]
        [Display(Name = "الاسم الكامل")]
        public string FullName { get; set; }

        [Required, StringLength(128)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "البريد الالكتروني غير صحيح")]
        [Display(Name = "البريد الالكتروني")]
        public string Email { get; set; }

        public string UserId { get; set; }


    }
}
