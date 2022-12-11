using GSI_Internal.Entites;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSI_Internal.Models
{
    public class ApplicationTransaction_Request_LogVM
    {
        [Key]
        public int ID { get; set; }
        public DateTime The_Date { get; set; }
        [Required]
        public string User_Code { get; set; }
        [Required]
        public string User_Name { get; set; }

        public int Item_code { get; set; }
        public string Note { get; set; }
        public string NumberOfTransiactionOfEntity { get; set; }
        public int Status_From { get; set; }
        public int Status_TO { get; set; }

        public string Status_From_Name { get; set; }
        public string Status_TO_Name { get; set; }

        public IFormFile File_Processing_VM { get; set; }
        public string File_Processing { get; set; }
        public string File_Name { get; set; }
        [Required]
        public Guid App_Code { get; set; }
        [ForeignKey("App_Code")]
        public ApplicationTransaction_Request ApplicationTransaction_Request { get; set; }
    }
}
