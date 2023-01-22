using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace GSI_Internal.Entites
{
    [Keyless]
    public class TaskStatusName
    {
       
        public int StatusAction_Code { get; set; }
        public string StatusName { get; set; }
    }
}
