using GSI_Internal.Entites;
using GSI_Internal.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GSI_Internal.Models
{
    public class ApplicationTransaction_RequestVM
    {

        [Key]
        public Guid ID { get; set; }
        [Required]
        public DateTime The_Date { get; set; }
        public int Move_Type { get; set; }
        [Required]
        [MaxLength(60)]
        public string ClientName { get; set; }

        [Required]
        public string ClientLastName { get; set; }
        public string Country_Name { get; set; }
        [Required]
        public string ClientPhone { get; set; }
        [EmailAddress]
        public string UserEmail { get; set; }
        [Required]
        public int TransiactionItem_Code { get; set; }
        [Required]
        public string TransiactionItem_Name { get; set; }
        public string ServicesPhoto { get; set; }
        [Required]
        public decimal TransiactionItem_GovernmentFees { get; set; }
        [Required]
        public decimal TransiactionItem_Price { get; set; }
        [Required]
        public decimal TransiactionItem_Net { get; set; }
        public string files { get; set; }
        public IFormFile files_Upload { get; set; }
        public string File_Name { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public string ClientNotes { get; set; }
        public string NumberOfTransiactionOfEntity { get; set; }
        public string TarnferUserFrom { get; set; }
        public string TarnferUserFrom_Name { get; set; }
        public string TransferUserTo { get; set; }
        public string TransferUserTo_Name { get; set; }
        public int count { get; set; }
        //
        public int TransactionGroupID{ get; set; }
        public string TransactionGroupNameEnglishName { get; set; }
        public string TransactionSubGroupNameEnglishName { get; set; }
        public int GroupCont { get; set; }
        //
        public bool IsTransfer { get; set; }
        public DateTime The_Date_log { get; set; }
        [Required]
        public string User_Code { get; set; }
        [Required]
        public string User_Name { get; set; }

        public int Item_code { get; set; }
        public string Note { get; set; }
        public int Status_From { get; set; }
        public int Status_TO { get; set; }

        //-----------------------Applicatiion Transfer
        public DateTime Transfer_Date { get; set; }
        public string userFrom { get; set; }
        public string userTo { get; set; }
        public int Status_Transfer { get; set; }

        //-----------------------

        public int IsProsessByUser { get; set; }
        public string UserProsessID { get; set; }
        public int ProsessID { get; set; }

        public DateTime StartTransactionTime { get; set; }

        public DateTime EndTransactionTime { get; set; }
        public ApplicationTrans_RequestVM ApplicationTrans_RequestVM { get; set; }
        public IEnumerable<RequirementsVM> RequirementsVM { get; set; }
        public IEnumerable<TransactionItemVM> TransactionItemVM { get; set; }
        public IEnumerable<AssignRequirmentToItemVM> AssignRequirmentToItemVM { get; set; }

        public IEnumerable<ApplicationTransaction_Request_LogVM> ApplicationTransaction_Request_LogVM { get; set; }
        public IEnumerable<ApplicationTransferVm> ApplicationTransferVm { get; set; }
        public IEnumerable<RequirmentsFileAttachmentVM> RequirmentsFileAttachmentVM { get; set; }
        public IEnumerable<RequestInquiry_Answer_VM> RequestInquiry_Answer_VM { get; set; }
        public IEnumerable<RequestSelectionVM> RequestSelectionVM { get; set; }
        public IEnumerable<ApplicationTransaction_Request_ProcessingVM> ApplicationTransaction_Request_ProcessingVM { get; set; }


    }
}
