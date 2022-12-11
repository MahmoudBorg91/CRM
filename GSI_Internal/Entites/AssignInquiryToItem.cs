using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSI_Internal.Entites
{
    [Table("tbl_AssignInquiryToItem")]
    public class AssignInquiryToItem
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int TransactionItemID { get; set; }
        [Required]
        public int InquiryID { get; set; }
        [ForeignKey("InquiryID")]
        public TransactionItemInquiry TransactionItemInquiry { get; set; }
        [ForeignKey("TransactionItemID")]
        public TransactionItem TransactionItem { get; set; }
    }
}
