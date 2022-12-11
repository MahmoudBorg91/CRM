using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSI_Internal.Entites
{
    [Keyless]
    [Table("tbl_StatusTransfer_Name")]
    public class StatusTransfer_Name
    {
        public int StatusAction_Code { get; set; }
        public string StatusAction_Name { get; set; }
    }
}
