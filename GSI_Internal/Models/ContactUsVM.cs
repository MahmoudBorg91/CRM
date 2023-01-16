using GSI_Internal.Models.EmailViewModel;
using System.ComponentModel.DataAnnotations;

namespace GSI_Internal.Models
{
    public class ContactUsVM
    {
        public int Id { get; set; }

        [Display(Name = "رقم الواتس اب ")]
        public string WhatsAppNumber { get; set; }

        [Display(Name = "الايميل ")]
        public string Email { get; set; }

        [Display(Name = "لينك الموقع ")]
        public string Link { get; set; }

        [Display(Name = "لينك الفيسبوك ")]
        public string FaceBookLink { get; set; }
        [Display(Name = "لينك الانستا ")]
        public string InstagramLink { get; set; }
        [Display(Name = "لينك تويتر ")]
        public string TwitterLink { get; set; }
        [Display(Name = "لينك اليوتيوب ")]
        public string YouTubeLink { get; set; }
        [Display(Name = "لينك لينكد ان ")]
        public string LinkedInLink { get; set; }


        [Display(Name = "رقم الهاتف ")]
        public string PhoneNumber { get; set; }
        [Display(Name = " العنوان ")]
        public string Location { get; set; }

        [Display(Name = "شروط وأحكام")]
        public string TermsAndConditions { get; set; }

        [Display(Name = "شروط وأحكام عربي")]
        public string TermsAndConditionsAr { get; set; }

        //-------------------------------------------------------------Borg
        [Display(Name = "رقم الهاتف2 ")]
        public string PhoneNumber2 { get; set; }
        [Display(Name = "  العنوان عربى ")]
        public string LocationAr { get; set; }
        public string PrivacyAndPolicy { get; set; }
        public string PrivacyAndPolicyAr { get; set; }
        public string RefundPolicy { get; set; }
        public string RefundPolicyAr { get; set; }

        public MailContactUs_Vm MailContactUs_Vm { get; set; }
    }
}
