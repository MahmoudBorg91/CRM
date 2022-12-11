using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSI_Internal.Entites
{
    [Table("tbl_ApplicationTransaction_Request_Processing")]
    public class ApplicationTransaction_Request_Processing
    {
        public int ID { get; set; }
       
        public string UserID { get; set; }
        public DateTime StartTransactionTime { get; set; }
        public DateTime EndTransactionTimeToProcess { get; set; }
        public DateTime EndTransactionTime { get; set; }
        public int ActiveStatus { get; set; }
        [Required]
        public Guid App_Code { get; set; }
        [ForeignKey("App_Code")]
        public ApplicationTransaction_Request ApplicationTransaction_Request { get; set; }
        


    }
}
