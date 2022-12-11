using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GSI_Internal.Entites;

namespace GSI_Internal.Models
{
    public class AssignInquireytToItemVM
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

        public string InquiryName_Arabic { get; set; }
        [Required]
        public string InquiryName_English { get; set; }
        [Required]
        public int Inquiry_Type { get; set; }
    }
}
