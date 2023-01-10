using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GSI_Internal.Entites
{
    [Table("tbl_SlideShow")]
    public class SlideShow
    {
        [Key]
        public int ID { get; set; }
        public string SlideImage { get; set; }
        public string Title_English { get; set; }
        public string Title_Arabic { get; set; }
        public string ReSizeme_English { get; set; }
        public string ReSizeme_Arabic { get; set; }
        public bool ShowInMobile { get; set; }
        public bool ShowInWeb { get; set; }


    }
}
