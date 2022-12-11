using Microsoft.AspNetCore.Identity;

namespace GSI_Internal.Models
{
    public class ApplicationUserVM : IdentityUser
    {
        public string FullNmae { get; set; }
    }
}
