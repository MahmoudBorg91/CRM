using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSI_Internal.Entites
{
    [Table("tbl_Solution")]
    public class Solution
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string SoulutionNAme { get; set; }
    }
}
