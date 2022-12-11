using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GSI_Internal.Models.ViewModel
{
    public class drpInquiry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SelectListItem> drpInquirys { get; set; }
        [Display(Name = "Inquiry")]
        public int[] InquirysIds { get; set; }
    }
}
