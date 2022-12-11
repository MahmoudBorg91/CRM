using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GSI_Internal.Models.ViewModel
{
    public class drpRequirmemt
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SelectListItem> drpRequirment { get; set; }
        [Display(Name = "Requirments")]
        public int[] RequirmentsIds { get; set; }
    }
}
