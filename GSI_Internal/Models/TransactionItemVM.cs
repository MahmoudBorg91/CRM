using GSI_Internal.Entites;
using GSI_Internal.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSI_Internal.Models
{
    public class TransactionItemVM
    {
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
        public string image { get; set; }
        public IFormFile ServicesPhotoVM { get; set; }
        public string ServicesPhoto { get; set; }
        public string ServicesDecription_Arabic { get; set; }
        public string ServicesDecription_English { get; set; }
        public bool SetInMostServices { get; set; }
        public bool SetInMostServices_INSubGroup { get; set; }
        public string Time_Services_Arabic { get; set; }
        public string Time_Services_English { get; set; }

        [ForeignKey("TransactionGroupID")]

        public TransactionGroup TransactionGroup { get; set; }

        public string TransactionGroupName { get; set; }
        public string TransactionGroupNameEnglish { get; set; }
        public string TransactionSubGroupName { get; set; }

        public string TransactionGroupNameEnglis { get; set; }
        public string TransactionSubGroupNameEnglish { get; set; }
        public string Services_Conditions_Arabic { get; set; }
        public string Services_Conditions_English { get; set; }


        public virtual ICollection<AssignRequirmentToItem> ItemRequirs { get; set; }
        public IEnumerable<AssignRequirmentToItemVM> AssignRequirmentToItemVM { get; set; }

        public IEnumerable<ApplicationTrans_RequestVM> ApplicationTrans_RequestVM { get; set; }
        public IEnumerable<RequirmentsFileAttachmentVM> RequirmentsFileAttachmentVM { get; set; }
        public IEnumerable<TransactionSubGroupVM> TransactionSubGroupVM { get; set; }

        public IEnumerable<AssignInquireytToItemVM> AssignInquireytToItemVM { get; set; }
        public IEnumerable<RequestInquiry_Answer_VM> RequestInquiry_Answer_VM { get; set; }
        public IEnumerable<RequestSelectionVM> RequestSelectionVM { get; set; }
        public IEnumerable<ClientWalletVM> ClientWalletVM { get; set; }




    }
}
