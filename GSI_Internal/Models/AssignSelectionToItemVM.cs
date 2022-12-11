using System.ComponentModel.DataAnnotations.Schema;
using GSI_Internal.Entites;
using MessagePack;
using Microsoft.Build.Framework;

namespace GSI_Internal.Models
{
    public class AssignSelectionToItemVM
    {
      
        public int ID { get; set; }
        [Required]
        public int TransactionItemID { get; set; }
        [Required]
        public int SelectionID { get; set; }
        [ForeignKey("SelectionID")]
        public TransiactionItem_Selection TransiactionItem_Selection { get; set; }
        [ForeignKey("TransactionItemID")]
        public TransactionItem TransactionItem { get; set; }
        public string SelectionName_Arabic { get; set; }
       
        public string SelectionName_English { get; set; }


    }
}
