using GSI_Internal.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSI_Internal.Models
{
    public class DemoRequestMainVM
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int LeadID { get; set; }

        public string CustName { get; set; }
        [Required]
        public DateTime Demo_Date { get; set; }
        [Required]
        public DateTime Demo_time { get; set; }
        [Required]
        public int NumberOfAtt { get; set; }
        [Required]
        public string Compettior { get; set; }
        [Required]
        public string Note { get; set; }

        [ForeignKey("LeadID")]
        public Lead Lead { get; set; }

        public string DemoRequestSubs { get; set; }

        public List<DemoRequestSubVM> DemoRequestSubsList { get; set; }
    }
}
