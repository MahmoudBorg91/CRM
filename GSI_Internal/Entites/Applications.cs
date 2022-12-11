using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSI_Internal.Entites
{
    [Table("tbl_Application")]
    public class Applications
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string AppName { get; set; }
        [Required]
        public int IDofSoulution { get; set; }
        public string SoulutionName { get; set; }

        [ForeignKey("IDofSoulution")]
        public Solution Solution { get; set; }

    }
}
