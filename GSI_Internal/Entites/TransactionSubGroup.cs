using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GSI_Internal.Entites
{
    [Table("tbl_TransactionSubGroup")]
    public class TransactionSubGroup
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string SubGroupNameArabic { get; set; }
        [Required]
        public string SubGroupNameEnglish { get; set; }
        [Required]
        public int TransactionGroupID { get; set; }
        [ForeignKey("TransactionGroupID")]
        public TransactionGroup TransactionGroup { get; set; }

        public virtual ICollection<TransactionItem> TransactionItems { get; set; }



    }
}
