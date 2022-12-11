using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace GSI_Internal.Models
{
    public class LeadVM
    {
        [Key]
        public int ID { get; set; }
        public DateTime theDate { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string cutomerName { get; set; }
        [Required]

        public string cutomerPhone { get; set; }
        [Required]
        public string BrandName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int BranchCount { get; set; }
        [Required]
        public string Note { get; set; }
        public string image { get; set; }
        public IFormFile logo { get; set; }



    }
}
