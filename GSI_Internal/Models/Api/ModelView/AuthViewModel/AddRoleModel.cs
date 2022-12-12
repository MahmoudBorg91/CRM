using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GSI_Internal.Models.Api.ModelView.AuthViewModel
{
    public class AddRoleModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public List<string> Roles { get; set; } = new();
    }
}
