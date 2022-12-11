using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GSI_Internal.Entites
{
    [Table("tbl_RequirmentsFileAttachment")]
    public class RequirmentsFileAttachment
    {


        public int Id { get; set; }
        public Guid App_Code { get; set; }
        public int  RequireID { get; set; }
        public string FileName { get; set; }
        public string UserID { get; set; }

        [ForeignKey("App_Code")]
        public ApplicationTransaction_Request ApplicationTransaction_Request { get; set; }
        [ForeignKey("RequireID")]
        public Requirements Requirements { get; set; }
    
    }
}
