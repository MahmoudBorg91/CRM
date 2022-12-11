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
            ItemRequirs = new HashSet<AssignRequirmentToItem>();
            ItemInquiry= new HashSet<AssignInquiryToItem>();
            ItemSelection = new HashSet<AssignSelectionToItem>();
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

        [ForeignKey("TransactionGroupID")]
        public TransactionGroup TransactionGroup { get; set; }
        public virtual ICollection<AssignRequirmentToItem> ItemRequirs { get; set; }
        public virtual ICollection<AssignInquiryToItem> ItemInquiry { get; set; }

        public virtual ICollection<AssignSelectionToItem> ItemSelection { get; set; }
    }
}
