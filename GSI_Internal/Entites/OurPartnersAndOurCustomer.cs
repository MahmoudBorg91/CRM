
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GSI_Internal.Entites
{
    public class OurPartnersAndOurCustomer
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
        public bool IsPartners { get; set; } // True -Partanter // False Custommer
    }
}
