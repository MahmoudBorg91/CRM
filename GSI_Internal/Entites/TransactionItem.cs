using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSI_Internal.Entites
{
    [Table("tbl_TransactionItem")]
    public class TransactionItem
    {
        public TransactionItem()
        {
            AssignRequirmentToItems = new HashSet<AssignRequirmentToItem>();
            AssignInquiryToItems= new HashSet<AssignInquiryToItem>();
            AssignSelectionToItems = new HashSet<AssignSelectionToItem>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        public int TransactionGroupID { get; set; }

        [Required]
        public int TransactionSubGroupID { get; set; }

        [Required]
        public string TransactionNameArabic { get; set; }
        [Required]
        public string TransactionNameEnglish { get; set; }
        [Required]
        public decimal GovernmentFees { get; set; }
        [Required]
        public decimal Price { get; set; }

        public string ServicesPhoto { get; set; }
        public string ServicesDecription_Arabic { get; set; }
        public string ServicesDecription_English { get; set; }
        public bool SetInMostServices { get; set; }
        public bool SetInMostServices_INSubGroup { get; set; }
        public string Time_Services_Arabic { get; set; }
        public string Time_Services_English { get; set; }
        public string Services_Conditions_Arabic { get; set; }
        public string Services_Conditions_English { get; set; }
        public string Icon { get; set; }
        public int TransactionItemTypeId { get; set; }
        public int? NextSubservicesID { get; set; }

        public bool IsNotAvailbale { get; set; }

        [ForeignKey("TransactionGroupID")]
        public TransactionGroup TransactionGroup { get; set; }

        [ForeignKey("TransactionSubGroupID")]
        public TransactionSubGroup TransactionSubGroup { get; set; }
        [ForeignKey("TransactionItemTypeId")]
        public TransactionItem_Type TransactionItemType { get; set; }

        public virtual ICollection<AssignRequirmentToItem> AssignRequirmentToItems { get; set; }
        public virtual ICollection<AssignInquiryToItem> AssignInquiryToItems { get; set; }

        public virtual ICollection<AssignSelectionToItem> AssignSelectionToItems { get; set; }
    }
}
