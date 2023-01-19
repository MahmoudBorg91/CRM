using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace GSI_Internal.Entites
{
    public class TaskDocuments_tbl
    {
        [Key]
        public int ID { get; set; }
       
        [Required]
        public DateTime UploadDate { get; set; }
        [Required]
        public string fileName { get; set; }
        [Required]
        public string UploadByUser { get; set; }
        [Required]
        public int TaskID { get; set; }
        [ForeignKey("TaskID")]
        public TaskMain TaskMain { get; set; }
    }
}
