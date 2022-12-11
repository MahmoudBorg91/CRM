using System;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using GSI_Internal.Entites;
using Microsoft.Build.Framework;

namespace GSI_Internal.Models
{
    public class RequestSelectionVM
    {

        public int ID { get; set; }
        public Guid App_Code { get; set; }
        public int SelectionID { get; set; }
        public bool IsSelected { get; set; }
        public string SelectionName_Arabic { get; set; }
       
        public string SelectionName_English { get; set; }
        public int SelectionGroupID { get; set; }
        public string Selection_GroupName_Arab { get; set; }

        public string Selection_GroupName_English { get; set; }
        [ForeignKey("App_Code")]
        public ApplicationTransaction_Request ApplicationTransaction_Request { get; set; }
        [ForeignKey("SelectionID")]
        public TransiactionItem_Selection TransiactionItem_Selection { get; set; }
    }
}
