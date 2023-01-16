//using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GSI_Internal.Entites
{
    public class JopList
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
        public string SkilllevelArabic { get; set;}
        [Required]
        public string SkilllevelEnglish { get; set; }

    }
}
