using System.ComponentModel.DataAnnotations;

namespace GSI_Internal.Models
{
    public class Request_DataVM
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string RequestName { get; set; }
    }
}
