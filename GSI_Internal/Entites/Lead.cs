using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSI_Internal.Entites
{
    [Table("tbllead")]
    public class Lead
    {
        [Key]
        public int ID { get; set; }
        public DateTime theDate { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string cutomerName { get; set; }
        [Required]
        public string cutomerPhone { get; set; }
        [Required]

        public string BrandName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int BranchCount { get; set; }
        [Required]
        public string Note { get; set; }

        public string logo { get; set; }




    }
}
