using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace GSI_Internal.Models
{
    public class TransactionItem_TypeVM
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string NameArabic { get; set; }
        [Required]
        public string NameEnglish { get; set; }
        public string Icon { get; set; }
        public IFormFile IconIFormFile { get; set; }
    }
}
