using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NuGet.Common;

namespace GSI_Internal.Models.EmailViewModel
{
    public class MailContactUs_Vm
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Note { get; set; }

      
    }
}
