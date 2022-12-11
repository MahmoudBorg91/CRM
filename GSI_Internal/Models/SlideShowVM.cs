using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace GSI_Internal.Models
{
    public class SlideShowVM
    {
        [Key]
        public int ID { get; set; }
        public string SlideImage { get; set; }
        public IFormFile SlideImageFormFile { get; set; }
        public string Title_English { get; set; }
        public string Title_Arabic { get; set; }
        public string ReSizeme_English { get; set; }
        public string ReSizeme_Arabic { get; set; }

    }
}
