using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GSI_Internal.Entites;

namespace GSI_Internal.Models.ViewModel
{
    public class ApplicationTrans_RequestVM

    {

        public Guid ID { get; set; }
        [DataType(DataType.Date)]
        public DateTime The_Date { get; set; }
        public string ClientID { get; set; }
        public int Move_Type { get; set; }

        public string ClientName { get; set; }
        [MaxLength(60)]
        
        public string ClientLastName { get; set; }

        public string ClientPhone { get; set; }
        public string Country_Name { get; set; }

        public string UserEmail { get; set; }

        public int TransiactionItem_Code { get; set; }
        public string TransiactionItem_Name { get; set; }
        public string TransiactionItem_NameEnglish { get; set; }

        public string TarnferUserFrom { get; set; }
        public string TarnferUserFrom_Name { get; set; }
        public string TransferUserTo { get; set; }
        public string TransferUserTo_Name { get; set; }
        public string ServicesPhoto { get; set; }
        public string StatusName { get; set; }
        
        public decimal TransiactionItem_GovernmentFees { get; set; }

        public decimal TransiactionItem_Price { get; set; }

        public decimal TransiactionItem_Net { get; set; }
        public string files { get; set; }
        public IFormFile files_Upload { get; set; }
        public int Status { get; set; }
        public string Status_Name { get; set; }
        public string ClientNotes { get; set; }
        public string NumberOfTransiactionOfEntity { get; set; }
        public int IsProsessByUser { get; set; }
        public string UserProsessID { get; set; }
        public string Note { get; set; }
        public ApplicationTransaction_Request_LogVM ApplicationTransaction_Request_LogVM { get; set; }
        public IEnumerable<RequirementsVM> RequirementsVM { get; set; }
        public IEnumerable<TransactionItemVM> TransactionItemVM { get; set; }
        public IEnumerable<AssignRequirmentToItemVM> AssignRequirmentToItemVM { get; set; }
        public List<RequestInquiry_Answer_VM> AssignInquireytToItemVM { get; set; }
        public List<RequirmentsFileAttachmentVM> RequirmentsFileAttachmentVM { get; set; }
        public List<RequestInquiry_Answer_VM> RequestInquiry_Answer_VM { get; set; }
        public List<RequestSelectionVM> RequestSelectionVM { get; set; }
       
        public string ApplicationFile { get; set; }
        public List<ApplocationRequireList> ApplocationRequireList { get; set; }
        public List<ClientWalletVM> ClientWalletVM { get; set; }









    }
}
