﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GSI_Internal.Entites
{
    [Table("tbl_TransactionGroup")]
    public class TransactionGroup
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string TransactionGroup_NameArabic { get; set; }
        [Required]
        [MaxLength(50)]
        public string TransactionGroup_NameEnglish { get; set; }

        public string logo { get; set; }

        public string Icon { get; set; }


        public bool IsNotAvailbale { get; set; }
        
        public virtual ICollection<TransactionItem> TransactionItems { get; set; }

    }
}
