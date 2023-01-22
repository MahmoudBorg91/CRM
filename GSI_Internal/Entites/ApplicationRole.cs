using Microsoft.AspNetCore.Identity;

namespace GSI_Internal.Entites
{
    public class ApplicationRole : IdentityRole
    {
        public string NameAr { get; set; }

        public string Description { get; set; }

        public int RoleNumber { get; set; } = 0;
    }
}
