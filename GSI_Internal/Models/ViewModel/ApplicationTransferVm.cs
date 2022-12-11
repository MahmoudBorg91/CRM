using GSI_Internal.Entites;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSI_Internal.Models.ViewModel
{
    public class ApplicationTransferVm
    {
        [Key]
        public int ID { get; set; }

        public DateTime Transfer_Date { get; set; }
        public string userFrom { get; set; }
        public string userFrom_Name { get; set; }
        public string userTo { get; set; }
        public string userTo_Name { get; set; }
        public int Status_Transfer { get; set; }
        public string ClientName { get; set; }
        [MaxLength(60)]
        [Required]
        public string ClientLastName { get; set; }

        public string ClientPhone { get; set; }
        public string Country_Name { get; set; }

        public string UserEmail { get; set; }

        public int TransiactionItem_Code { get; set; }
        public string TransiactionItem_Name { get; set; }
        public string TransiactionItem_NameEnglish { get; set; }
        public int Status_App { get; set; }



        public decimal TransiactionItem_GovernmentFees { get; set; }

        public decimal TransiactionItem_Price { get; set; }

        public decimal TransiactionItem_Net { get; set; }
        [Required]
        public Guid App_Code { get; set; }
        [ForeignKey("App_Code")]
        public ApplicationTransaction_Request ApplicationTransaction_Request { get; set; }
    }
}
