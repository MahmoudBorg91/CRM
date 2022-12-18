using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace GSI_Internal.Models
{
    public class ClientWalletVM
    {
        public int Id { get; set; }
        
        public string UserId { get; set; }
        [Required]
        public int RequireID { get; set; }

        public DateTime TheDateFile { get; set; }
        public string FileName { get; set; }

        public IFormFile FileNameFormFile { get; set; }
    }
}
