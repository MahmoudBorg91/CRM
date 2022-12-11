using System.ComponentModel.DataAnnotations;

namespace GSI_Internal.Models
{
    public class TransactionItemInquiryVM
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string InquiryName_Arabic { get; set; }
        [Required]
        public string InquiryName_English { get; set; }
        [Required]
        public int Inquiry_Type { get; set; }
    }
}
