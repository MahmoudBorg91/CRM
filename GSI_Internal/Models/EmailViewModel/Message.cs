using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.Build.Framework;

namespace GSI_Internal.Models.EmailViewModel
{
    public class Message
    {
        [Required]
        public string ToEmail { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        public IList<IFormFile> Attachments { get; set; }
    }
}
