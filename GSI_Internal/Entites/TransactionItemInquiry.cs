using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GSI_Internal.Entites
{
    [Table("tbl_TransactionItemInquiry")]
    public class TransactionItemInquiry
    {
        [Key]
        public int ID  { get; set; }
        [Required]
        public string InquiryName_Arabic { get; set; }
        [Required]
        public string InquiryName_English { get; set; }
        [Required]
        public int Inquiry_Type { get; set; }
    }
}
