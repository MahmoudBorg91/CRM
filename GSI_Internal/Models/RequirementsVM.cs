using System.ComponentModel.DataAnnotations;
namespace GSI_Internal.Models
{
    public class RequirementsVM
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string RequirementName_Arabic { get; set; }
        [Required]
        public string RequirementName_English { get; set; }
    }
}
