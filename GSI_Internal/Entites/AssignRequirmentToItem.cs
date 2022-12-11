using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GSI_Internal.Entites
{
    [Table("tbl_AssignRequirmentToItem")]
    public class AssignRequirmentToItem
    {

        [Key]
        public int ID { get; set; }
        [Required]
        public int TransactionItemID { get; set; }
        [Required]
        public int RequirmentID { get; set; }
        [ForeignKey("RequirmentID")]
        public Requirements Requirements { get; set; }
        [ForeignKey("TransactionItemID")]
        public TransactionItem TransactionItem { get; set; }

    }
}
