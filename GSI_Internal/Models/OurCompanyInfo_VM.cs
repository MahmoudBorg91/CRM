using Microsoft.AspNetCore.Http;

namespace GSI_Internal.Models
{
    public class OurCompanyInfo_VM
    {
        public int ID { get; set; }
        public string AboutUS_Englis { get; set; }
        public string AboutUS_Arabic { get; set; }
        public string AboutUS_Image { get; set; }
        public string AboutUS_Icon { get; set; }
        public IFormFile AboutUS_ImageIFormFile { get; set; }
        public IFormFile AboutUS_IconIFormFile { get; set; }

        public string OurMission_Englis { get; set; }
        public string OurMission_Arabic { get; set; }
        public string OurMission_Image { get; set; }
        public string OurMission_Icon { get; set; }
        public IFormFile OurMission_ImageIFormFile { get; set; }
        public IFormFile OurMission_IconIFormFile { get; set; }
      
        public string OurVision_Englis { get; set; }
        public string OurVision_Arabic { get; set; }
        public string OurVision_Image { get; set; }
        public string OurVision_Icon { get; set; }
        public IFormFile OurVision_ImageIFormFile { get; set; }
        public IFormFile OurVision_IconIFormFile { get; set; }
       
        public string OurGoal_Englis { get; set; }
        public string OurGoal_Arabic { get; set; }
        public string OurGoal_Image { get; set; }
        public string OurGoal_Icon { get; set; }
        public IFormFile OurGoal_ImageIFormFile { get; set; }
        public IFormFile OurGoal_IconIFormFile { get; set; }

        public string OurValues_Englis { get; set; }
        public string OurValues_Arabic { get; set; }
        public string OurValues_Image { get; set; }
        public string OurValues_Icon { get; set; }
        public IFormFile OurValues_ImageIFormFile { get; set; }
        public IFormFile OurValues_IconIFormFile { get; set; }
    }
}
