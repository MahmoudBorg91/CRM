using GSI_Internal.Entites;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSI_Internal.Models
{
    public class FollowUpVM
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public DateTime The_Data { get; set; }
        [Required]
        public int CustomerID { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public DateTime time { get; set; }
        [Required]
        public int ActionCode { get; set; }
        [Required]
        public string ActionName { get; set; }
        [Required]
        public string Note { get; set; }
        [ForeignKey("CustomerID")]
        public Lead lead { get; set; }
    }
}
