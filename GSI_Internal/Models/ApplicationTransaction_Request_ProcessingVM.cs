using System.ComponentModel.DataAnnotations.Schema;
using System;
using GSI_Internal.Entites;
using Microsoft.Build.Framework;

namespace GSI_Internal.Models
{
    public class ApplicationTransaction_Request_ProcessingVM
    {
        public int ID { get; set; }

        public string UserID { get; set; }
        public DateTime StartTransactionTime { get; set; }
        public DateTime EndTransactionTime { get; set; }

        public int TimeNow { get; set; }
        public int TimeEnd { get; set; }
        public int ActiveStatus { get; set; }
        [Required]
        public Guid App_Code { get; set; }
        [ForeignKey("App_Code")]
        public ApplicationTransaction_Request ApplicationTransaction_Request { get; set; }
    }
}
