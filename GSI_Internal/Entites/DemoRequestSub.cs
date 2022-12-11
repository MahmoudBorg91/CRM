using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSI_Internal.Entites
{
    public class DemoRequestSub
    {


        [Key]
        public int ID { get; set; }

        public int IDOFSolution { get; set; }
        public int IDOFAplication { get; set; }


        [ForeignKey("IDOFAplication")]
        public Applications Applications { get; set; }


        [ForeignKey("DemoRequestMain")]
        public int DEMOID { get; set; }
        public DemoRequestMain DemoRequestMain { get; set; }


    }
}
