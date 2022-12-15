using Microsoft.AspNetCore.Identity;

namespace GSI_Internal.Entites
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // 0-employee 1-client 2-company
        public int UserType { get; set; } 
        
        public bool Status { get; set; } = true;
        public string DeviceToken { get; set; }
    }
}
