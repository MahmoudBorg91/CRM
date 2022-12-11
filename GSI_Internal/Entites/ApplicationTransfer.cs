using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GSI_Internal.Entites
{
    [Table("tbl_ApplicationTransfer")]
    public class ApplicationTransfer
    {
        [Key]
        public int ID { get; set; }
     
        public DateTime Transfer_Date { get; set; }
        public string userFrom { get; set; }
        public string userTo { get; set; }
        public int Status { get; set; }

        [Required]
        public Guid App_Code { get; set; }
        [ForeignKey("App_Code")]
        public ApplicationTransaction_Request ApplicationTransaction_Request { get; set; }
    }
}
