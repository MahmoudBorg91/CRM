using GSI_Internal.Entites;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSI_Internal.Models
{
    public class TransactionSubGroupVM
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
        public string TransactionGroupNameArabic { get; set; }
        public string TransactionGroupNameEnglish { get; set; }
        public int count { get; set; }

        public List<TransactionItemVM> TransactionItemVM { get; set; }


    }
}




