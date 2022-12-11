using System.ComponentModel.DataAnnotations;

namespace GSI_Internal.Models
{
    public class SolutionVM
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string SoulutionNAme { get; set; }
    }
}
