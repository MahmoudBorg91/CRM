using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GSI_Internal.Entites
{
    [Table("tbl_client_wallet")]
    public class client_wallet
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int RequireID { get; set; }

        public DateTime TheDateFile { get; set; }
        public string FileName { get; set; }
        [ForeignKey("RequireID")]
        public Requirements Requirements { get; set; }

    }
}
