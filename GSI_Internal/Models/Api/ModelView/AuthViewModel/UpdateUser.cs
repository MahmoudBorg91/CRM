using System.ComponentModel.DataAnnotations;

namespace GSI_Internal.Models.Api.ModelView.AuthViewModel
{
    public class UpdateUser
    {
        [ StringLength(50), MinLength(5)]
        public string FirstName { get; set; }
        [ StringLength(50), MinLength(5)]
        public string LastName { get; set; }

        [Required, StringLength(128)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "البريد الالكتروني غير صحيح")]
        public string Email { get; set; }



    }
}
