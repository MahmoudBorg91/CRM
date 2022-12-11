using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GSI_Internal.Entites
{
    [Table("tbl_RequestSelection_Group")]
    public class RequestSelection_Group
    {
        [Key]
        public int  ID { get; set; }
        [Required]
        public string Selection_GroupName_Arab { get; set; }
        [Required]
        public string Selection_GroupName_English { get; set; }
    }
}
