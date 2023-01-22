using GSI_Internal.Entites;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace GSI_Internal.Models
{
    public class TaskProcessing_Vm
    {
        
        public int ID { get; set; }
        public int TaskID { get; set; }
        public DateTime processDate { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserNote { get; set; }
        public int FromStatus { get; set; }
        public String FromStatusName { get; set; }
        public int ToStatus { get; set; }
        public String ToStatusName { get; set; }
        [ForeignKey("TaskID")]
        public TaskMain TaskMain { get; set; }
    }
}
