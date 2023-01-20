using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GSI_Internal.Entites
{
    public class TasksProcessing
    {
        [Key]
        public int ID  { get; set; }
        public int  TaskID { get; set; }
        public DateTime processDate { get; set; }
        public string UserId { get; set; }
        public string UserNote { get; set; }
        public int FromStatus { get; set; }
        public int ToStatus { get; set; }

        [ForeignKey("TaskID")]
        public TaskMain TaskMain { get; set; }
    }
}
