using GSI_Internal.Entites;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GSI_Internal.Models
{
    public class AssignRequirmentToItemVM
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int TransactionItemID { get; set; }
        public string TransactionItem_NameArabic { get; set; }
        public string TransactionItem_English { get; set; }
        [Required]
        public int RequirmentID { get; set; }
        [ForeignKey("RequirmentID")]
        public Requirements Requirements { get; set; }
        public string Requirements_NameArabic { get; set; }
        [Required]
        public decimal GovernmentFees { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Requirements_English { get; set; }
        [ForeignKey("TransactionItemID")]
        public TransactionItem TransactionItem { get; set; }

        public int TransactionGroupID { get; set; }
        public string TransactionGroupNameArabic { get; set; }

        public int TransactionSubGroupID { get; set; }
        public string TransactionSubGroupNameArabic { get; set; }
       
    }
}
