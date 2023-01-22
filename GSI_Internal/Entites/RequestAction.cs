using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GSI_Internal.Entites
{
    public class RequestAction
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int RequetDataID { get; set; }
        public string RequestFromUserID { get; set; }
        public DateTime DateOfCreate { get; set; }
        public DateTime DateOfStartRequest { get; set; }
        public DateTime DateOfEndtRequest { get; set; }
        public string Note { get; set; }
        public int status { get; set; }
        public string UserTakeAction { get; set; }
        public string NoteStatus { get; set; }
        [ForeignKey("RequetDataID")]
        public Requests_Data Requests_Data { get; set; }

    }
}
