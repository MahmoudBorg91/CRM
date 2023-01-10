using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSI_Internal.Entites
{
    [Table("tbl_TransactionItem_Type")]
    public class TransactionItem_Type
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string NameArabic { get; set; }
        [Required]
        public string NameEnglish { get; set; }
      
        public string Icon { get; set; }

    }
}
