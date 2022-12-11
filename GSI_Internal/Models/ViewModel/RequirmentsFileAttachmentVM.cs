using GSI_Internal.Entites;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSI_Internal.Models.ViewModel
{
    public class RequirmentsFileAttachmentVM
    {
        public int Id { get; set; }
        public Guid App_Code { get; set; }
        public int RequireID { get; set; }
        public string RequireName_Arabic { get; set; }
        public string RequireName_English { get; set; }
        public IFormFile FileName_FormFIle { get; set; }
        public string FileName { get; set; }
        public string UserID { get; set; }
        public DateTime AppDateTime { get; set; }


        [ForeignKey("App_Code")]
        public ApplicationTransaction_Request ApplicationTransaction_Request { get; set; }
        [ForeignKey("RequireID")]
        public Requirements Requirements { get; set; }

        public IEnumerable<RequirmentsFileAttachmentVM> FileHistoryName { get; set; }
        public string FileHistoryNameSave { get; set; }



    }
}
