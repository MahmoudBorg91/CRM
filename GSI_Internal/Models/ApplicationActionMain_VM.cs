using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
namespace GSI_Internal.Models
{
    public class ApplicationActionMain_VM
    {

        public Guid ID { get; set; }
        [Required]
        public int Move_Type { get; set; }
        public DateTime The_Date { get; set; }
        [Required]
        [MaxLength(60)]
        public string ClientName { get; set; }
        [Required]
        public string ClientLastName { get; set; }
        [Required]
        public string ClientPhone { get; set; }
        [EmailAddress]
        public string UserEmail { get; set; }
        [Required]
        public int TransiactionItem_Code { get; set; }
        [Required]
        public string TransiactionItem_Name { get; set; }
        [Required]
        public decimal TransiactionItem_GovernmentFees { get; set; }
        [Required]
        public decimal TransiactionItem_Price { get; set; }
        [Required]
        public decimal TransiactionItem_Net { get; set; }
        public string files { get; set; }
        public IFormFile files_Upload { get; set; }
        public int Status { get; set; }
        public string ClientNotes { get; set; }
    }
}
