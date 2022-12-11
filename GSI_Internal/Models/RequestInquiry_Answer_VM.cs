using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GSI_Internal.Entites;

namespace GSI_Internal.Models
{
    public class RequestInquiry_Answer_VM
    {
        public int ID { get; set; }
        public Guid App_Code { get; set; }
        public int InquiryID { get; set; }
        public string InquiryName_Arabic { get; set; }
       
        public string InquiryName_English { get; set; }
       
        public int Inquiry_Type { get; set; }
        public string Inquiry_Answer { get; set; }
        [ForeignKey("App_Code")]
        public ApplicationTransaction_Request ApplicationTransaction_Request { get; set; }
        [ForeignKey("InquiryID")]
        public TransactionItemInquiry TransactionItemInquiry { get; set; }
    }
}
