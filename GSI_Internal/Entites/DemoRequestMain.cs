using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSI_Internal.Entites
{
    public class DemoRequestMain
    {

        public DemoRequestMain()
        {
            DemoRequestSubs = new List<DemoRequestSub>();
        }

        [Key]
        public int ID { get; set; }
        [Required]
        public int LeadID { get; set; }
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



        public virtual List<DemoRequestSub> DemoRequestSubs { get; set; } = new List<DemoRequestSub>();
    }
}
