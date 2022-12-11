using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GSI_Internal.Models
{
    public class TransactionGroupVM
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Entity Arabic is required.")]
        [MaxLength(50)]
        
        public string TransactionGroup_NameArabic { get; set; }
        [Required(ErrorMessage = "Entity English is required.")]
        [MaxLength(50)]
        public string TransactionGroup_NameEnglish { get; set; }

        public string image { get; set; }
        public IFormFile logo { get; set; }
        public int  count { get; set; }
    }
}
