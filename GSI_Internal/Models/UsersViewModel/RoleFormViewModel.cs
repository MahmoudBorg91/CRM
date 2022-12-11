using System.ComponentModel.DataAnnotations;

namespace GSI_Internal.Models.ViewModel
{
    public class RoleFormViewModel
    {
        [Required, StringLength(256)]
        public string Name { get; set; }
    }
}