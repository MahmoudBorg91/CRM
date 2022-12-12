using System.ComponentModel.DataAnnotations;

namespace GSI_Internal.Models.Api.ModelView.AuthViewModel
{
    public class ChangePassword
    {
        [Required]
        public string OldPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
