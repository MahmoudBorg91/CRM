using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GSI_Internal.Entites
{
    [Table("tbl_Requirements")]
    public class Requirements
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string RequirementName_Arabic { get; set; }
        [Required]
        public string RequirementName_English { get; set; }
        
        public virtual ICollection<client_wallet> ClientWallets { get; set; }

    }
}
