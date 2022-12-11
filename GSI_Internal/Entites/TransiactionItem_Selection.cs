using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSI_Internal.Entites
{
    [Table("tbl_TransiactionItem_Selection")]
    public class TransiactionItem_Selection
    {
        [Key]
        public int ID { get; set; }
        [DefaultValue(1)]
        public int SelectionGroupID { get; set; }
        [Required]
        public string SelectionName_Arabic { get; set; }
      
        [Required]
        public string SelectionName_English { get; set; }
        
      
        [ForeignKey("SelectionGroupID")]
        public RequestSelection_Group RequestSelection_Group { get; set; }
    }
}
