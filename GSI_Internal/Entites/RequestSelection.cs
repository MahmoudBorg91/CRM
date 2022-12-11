using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSI_Internal.Entites
{
   
    public class RequestSelection
    {
        public int ID { get; set; }
        public Guid App_Code { get; set; }
        public int SelectionID { get; set; }
        public bool IsSelected { get; set; }


        [ForeignKey("App_Code")]
        public ApplicationTransaction_Request ApplicationTransaction_Request { get; set; }
        [ForeignKey("SelectionID")]
        public TransiactionItem_Selection TransiactionItem_Selection { get; set; }
    }
}
