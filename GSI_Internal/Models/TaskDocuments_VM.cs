using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GSI_Internal.Entites;
using Microsoft.AspNetCore.Http;

namespace GSI_Internal.Models
{
    public class TaskDocuments_VM
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int TaskID { get; set; }
        [Required]
        public DateTime UploadDate { get; set; }
        [Required]
        public string fileName { get; set; }
        [Required]
        public string UploadByUser { get; set; }
        public IFormFile fileNameFormFile { get; set; }
        [ForeignKey("TaskID")]
        public virtual TaskMain TaskMain { get; set; }
    }
}
