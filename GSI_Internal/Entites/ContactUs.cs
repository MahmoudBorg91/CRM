using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace GSI_Internal.Entites;

public class ContactUs
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
    public string LinkedInLink  { get; set; }


    [Display(Name = "رقم الهاتف ")]
    public string PhoneNumber { get; set; }

    public string Location { get; set; }

    [Display(Name = "شروط وأحكام")]
    public string TermsAndConditions { get; set; }

    [Display(Name = "شروط وأحكام عربي")]
    public string TermsAndConditionsAr { get; set; }

    //-------------------------------------------------------------


}