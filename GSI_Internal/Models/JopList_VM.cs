using System.ComponentModel.DataAnnotations;

namespace GSI_Internal.Models
{
    public class JopList_VM
    {
        public int ID { get; set; }
        [Required]
        public string JopNameArabic { get; set; }
        [Required]
        public string JopNameEnglish { get; set; }
        [Required]
        public string JopCode { get; set; }
        [Required]
        public string occupationCode { get; set; }
        [Required]
        public string qualificationArabic { get; set; }
        [Required]
        public string qualificationEnglish { get; set; }
        [Required]
        public string SkilllevelArabic { get; set; }
        [Required]
        public string SkilllevelEnglish { get; set; }
    }
}
