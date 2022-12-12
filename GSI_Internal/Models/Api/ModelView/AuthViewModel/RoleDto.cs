using System.ComponentModel.DataAnnotations;

namespace GSI_Internal.Models.Api.ModelView.AuthViewModel
{
    public class RoleDto
    {
        [Required]
        public string RoleName { get; set; }

        [Required]
        public string RoleNameAr { get; set; }

        public string Description { get; set; }

        public int GroupNumber { get; set; }
    }
}
