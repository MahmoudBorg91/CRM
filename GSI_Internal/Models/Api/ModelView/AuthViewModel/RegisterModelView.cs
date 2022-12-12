using System.ComponentModel.DataAnnotations;

namespace GSI_Internal.Models.Api.ModelView.AuthViewModel
{
    public class RegisterModelView
    {
        [Required, StringLength(50), MinLength(5)]
        public string FirstName { get; set; }
        [Required, StringLength(50), MinLength(5)]
        public string LastName { get; set; }

        [Required, StringLength(128)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "البريد الالكتروني غير صحيح")]
        public string Email { get; set; }

        [Required, StringLength(256)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, StringLength(256)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }





    }
}
