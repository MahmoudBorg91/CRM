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
        public int Move_Type { get; set; }// default 0
        [Required]
        public DateTime The_Date { get; set; } // default now
        [Required]
        public string ClientID { get; set; } // default UserId
        [Required]
        [MaxLength(60)]
        public string ClientName { get; set; } // default First Name
        [MaxLength(60)]
        [Required]
        public string ClientLastName { get; set; } // default Last Name
        [Required]
        public string ClientPhone { get; set; } // default Phone
        [EmailAddress]
        public string UserEmail { get; set; } // default Email

        public string Country_Name { get; set; } // default Country
        [Required]
        public int TransiactionItem_Code { get; set; } // default transaction item Id 
        [Required]
        public string TransiactionItem_Name { get; set; } // default transaction item name english
        [Required]
        public decimal TransiactionItem_GovernmentFees { get; set; } // default transaction item government fees
        [Required]
        public decimal TransiactionItem_Price { get; set; } // default transaction item price
        [Required]
        public decimal TransiactionItem_Net { get; set; } // default transaction item government fees + price
        public string files { get; set; }
        public int Status { get; set; } // default 0
        public string ClientNotes { get; set; } // default null

        public string NumberOfTransiactionOfEntity { get; set; } // default null 

        public string TarnferUserFrom { get; set; } // default null
        public string TransferUserTo { get; set; } // default null



        public int IsProsessByUser { get; set; } // default 0
        public string UserProsessID { get; set; } // default null
        public int? ProsessID { get; set; } // default null







        public virtual List<RequirmentsFileAttachment> RequirmentsFileAttachments { get; set; } = new List<RequirmentsFileAttachment>();
        public virtual List<RequestInquiry_Answer> RequestInquiry_Answer { get; set; } = new List<RequestInquiry_Answer>();
        public virtual List<RequestSelection> RequestSelection { get; set; } = new List<RequestSelection>();


    }
}
