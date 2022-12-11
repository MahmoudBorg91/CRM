using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GSI_Internal.Entites;

namespace GSI_Internal.Models
{
    public class TransiactionItem_SelectionVM
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string SelectionName_Arabic { get; set; }
        [Required]
        public string SelectionName_English { get; set; }
        public int SelectionGroupID { get; set; }
        public string Selection_GroupName_Arab { get; set; }
    
        public string Selection_GroupName_English { get; set; }
        [ForeignKey("SelectionGroupID")]
        public RequestSelection_Group RequestSelection_Group { get; set; }

    }
}
