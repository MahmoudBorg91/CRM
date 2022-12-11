using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GSI_Internal.Entites
{
    [Table("tbl_ApplicationTransaction_Request")]
    public class ApplicationTransaction_Request
    {

        public ApplicationTransaction_Request()
        {
            RequirmentsFileAttachments = new List<RequirmentsFileAttachment>();
            RequestInquiry_Answer = new List<RequestInquiry_Answer>();
            RequestSelection = new List<RequestSelection>();
        }

        [Key]
        public Guid ID { get; set; }
        public int Move_Type { get; set; }
        [Required]
        public DateTime The_Date { get; set; }
        [Required]
        public string ClientID { get; set; }
        [Required]
        [MaxLength(60)]
        public string ClientName { get; set; }
        [MaxLength(60)]
        [Required]
        public string ClientLastName { get; set; }
        [Required]
        public string ClientPhone { get; set; }
        [EmailAddress]
        public string UserEmail { get; set; }

        public string Country_Name { get; set; }
        [Required]
        public int TransiactionItem_Code { get; set; }
        [Required]
        public string TransiactionItem_Name { get; set; }
        [Required]
        public decimal TransiactionItem_GovernmentFees { get; set; }
        [Required]
        public decimal TransiactionItem_Price { get; set; }
        [Required]
        public decimal TransiactionItem_Net { get; set; }
        public string files { get; set; }
        public int Status { get; set; }
        public string ClientNotes { get; set; }

        public string NumberOfTransiactionOfEntity { get; set; }

        public string TarnferUserFrom { get; set; } 
        public string TransferUserTo { get; set; }



        public int IsProsessByUser { get; set; }
        public string UserProsessID { get; set; }
        public int? ProsessID { get; set; }







        public virtual List<RequirmentsFileAttachment> RequirmentsFileAttachments { get; set; } = new List<RequirmentsFileAttachment>();
        public virtual List<RequestInquiry_Answer> RequestInquiry_Answer { get; set; } = new List<RequestInquiry_Answer>();
        public virtual List<RequestSelection> RequestSelection { get; set; } = new List<RequestSelection>();


    }
}
