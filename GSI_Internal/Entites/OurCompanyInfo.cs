using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GSI_Internal.Entites
{
    [Table("tbl_OurCompanyInfo")]
    public class OurCompanyInfo
    {
        [Key]
        public int ID { get; set; }
        public string AboutUS_Englis { get; set; }
        public string AboutUS_Arabic { get; set; }
        public string AboutUS_Image { get; set; }
        public string AboutUS_Icon { get; set; }

        public string OurMission_Englis { get; set; }
        public string OurMission_Arabic { get; set; }
        public string OurMission_Image { get; set; }
        public string OurMission_Icon { get; set; }

        public string OurVision_Englis { get; set; }
        public string OurVision_Arabic { get; set; }
        public string OurVision_Image { get; set; }
        public string OurVision_Icon { get; set; }

        public string OurGoal_Englis { get; set; }
        public string OurGoal_Arabic { get; set; }
        public string OurGoal_Image { get; set; }
        public string OurGoal_Icon { get; set; }

        public string OurValues_Englis { get; set; }
        public string OurValues_Arabic { get; set; }
        public string OurValues_Image { get; set; }
        public string OurValues_Icon { get; set; }

    }
}
