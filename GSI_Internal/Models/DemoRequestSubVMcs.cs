using GSI_Internal.Entites;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSI_Internal.Models
{
    public class DemoRequestSubVMcs
    {

        public DemoRequestSubVMcs()
        {

        }

        [Key]
        public int ID { get; set; }

        public int DEMOID { get; set; }

        public int IDOFSolution { get; set; }

        [ForeignKey("DEMOID")]
        public DemoRequestMain DemoRequestMain { get; set; }

        public int IDOFAplication { get; set; }


        [ForeignKey("IDOFAplication")]
        public Applications Applications { get; set; }
    }
}
