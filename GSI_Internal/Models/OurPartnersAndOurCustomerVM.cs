using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace GSI_Internal.Models
{
    public class OurPartnersAndOurCustomerVM
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string NameAr { get; set; }
        [Required]
        public string NameEnglish { get; set; }
        [Required]
        public string NoteAr { get; set; }
        [Required]
        public string NoteEng { get; set; }
        public string Image { get; set; }
        public IFormFile ImageIFormFile { get; set; }
        public bool IsPartners { get; set; } // True -Partanter // False Custommer
        public string PrinterType { get; set; }
    }
}
