using System.ComponentModel.DataAnnotations;

namespace GSI_Internal.Models
{
    public class RequestSelection_GroupVM
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Selection_GroupName_Arab { get; set; }
        [Required]
        public string Selection_GroupName_English { get; set; }
    }

}
