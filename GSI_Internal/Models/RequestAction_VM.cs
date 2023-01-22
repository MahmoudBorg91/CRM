using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace GSI_Internal.Models
{
    public class RequestAction_VM
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int RequetDataID { get; set; }

        public string RequestName { get; set; }
        public string RequestFromUserID { get; set; }
        public string RequestFromUserName { get; set; }
        public DateTime DateOfCreate { get; set; }
        public DateTime DateOfStartRequest { get; set; }
        public DateTime DateOfEndtRequest { get; set; }
        public string Note { get; set; }
        public int status { get; set; }
        public string UserTakeAction { get; set; }
        public string UserTakeActionName { get; set; }
        public string NoteStatus { get; set; }
       
    }
}
