
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GSI_Internal.Entites
{
    public class Requests_Data
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string RequestName { get; set; }
    }
}
