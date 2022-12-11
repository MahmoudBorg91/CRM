using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSI_Internal.Entites
{
    [Table("tbl_AssignSelectionToItem")]
    public class AssignSelectionToItem
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int TransactionItemID { get; set; }
        [Required]
        public int SelectionID { get; set; }
        [ForeignKey("SelectionID")]
        public TransiactionItem_Selection TransiactionItem_Selection { get; set; }
        [ForeignKey("TransactionItemID")]
        public TransactionItem TransactionItem { get; set; }
    }
}
