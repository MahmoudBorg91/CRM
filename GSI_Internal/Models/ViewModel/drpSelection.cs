using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GSI_Internal.Models.ViewModel
{
    public class drpSelection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SelectListItem> drpSelections { get; set; }
        [Display(Name = "Selection")]
        public int[] SelectionIds { get; set; }
    }
}
