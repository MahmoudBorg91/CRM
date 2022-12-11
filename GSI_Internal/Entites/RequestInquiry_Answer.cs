using System;
using System.ComponentModel.DataAnnotations.Schema;
using GSI_Internal.Models;

namespace GSI_Internal.Entites
{
    [Table("tbl_RequestInquiry_Answer")]
    public class RequestInquiry_Answer
    {
        public int ID { get; set; }
        public Guid App_Code { get; set; }
        public int InquiryID  { get; set; }
        public string Inquiry_Answer { get; set; }


        [ForeignKey("App_Code")]
        public ApplicationTransaction_Request ApplicationTransaction_Request { get; set; }
        [ForeignKey("InquiryID")]
        public TransactionItemInquiry TransactionItemInquiry { get; set; }
    }
}
