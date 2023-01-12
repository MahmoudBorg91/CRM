using System.Collections.Generic;
using System.Linq;
using GSI_Internal.Context;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.OurCompanyInfoRepo
{
    public class OurCompanyInfoRepo:IOurCompanyInfoRepo
    {
        private readonly dbContainer _db;

        public OurCompanyInfoRepo(dbContainer db)
        {
            _db = db;
        }
        public IEnumerable<OurCompanyInfo> GetAll()
        {
            var data = _db.OurCompanyInfo.Select(a => a);
            return data;
        }

        public OurCompanyInfo GetByID(int id)
        {
            var data = _db.OurCompanyInfo.Find(id);
            return data;
        }

        public OurCompanyInfo AddObj(OurCompanyInfo obj)
        {
            var data = _db.OurCompanyInfo.Add(obj);
            _db.SaveChanges();
            return obj;

        }

        public OurCompanyInfo UpdateObj(OurCompanyInfo obj)
        {
            var editData = _db.OurCompanyInfo.Find(obj.ID);
            editData.ID = obj.ID;
            editData.AboutUS_Englis= obj.AboutUS_Englis;
            editData.AboutUS_Arabic = obj.AboutUS_Arabic;
            if (obj.AboutUS_Image != null)
            {
                editData.AboutUS_Image = obj.AboutUS_Image;
            }
            if (obj.AboutUS_Icon != null)
            {
                editData.AboutUS_Icon = obj.AboutUS_Icon;
            }
           
            
            editData.OurMission_Arabic = obj.OurMission_Arabic;
            editData.OurMission_Englis = obj.OurMission_Englis;
            if (obj.OurMission_Image != null)
            {
                editData.OurMission_Image = obj.OurMission_Image;
            }
            if (obj.OurMission_Icon != null)
            {
                editData.OurMission_Icon = obj.OurMission_Icon;
            }


            editData.OurVision_Arabic = obj.OurVision_Arabic;
            editData.OurVision_Englis = obj.OurVision_Arabic;
            if (obj.OurVision_Image != null)
            {
                editData.OurVision_Image = obj.OurVision_Image;
            }
            if (obj.OurVision_Icon != null)
            {
                editData.OurVision_Icon = obj.OurVision_Icon;
            }

            editData.OurGoal_Arabic = obj.OurGoal_Arabic;
            editData.OurGoal_Englis = obj.OurGoal_Englis;
            if (obj.OurGoal_Image != null)
            {
                editData.OurGoal_Image = obj.OurGoal_Image;
            }
            if (obj.OurGoal_Icon != null)
            {
                editData.OurGoal_Icon = obj.OurGoal_Icon;
            }

            editData.OurValues_Arabic = obj.OurValues_Arabic;
            editData.OurValues_Englis = obj.OurValues_Englis;
            if (obj.OurValues_Image != null)
            {
                editData.OurValues_Image = obj.OurValues_Image;
            }
            if (obj.OurValues_Icon != null)
            {
                editData.OurValues_Icon = obj.OurValues_Icon;
            }

            _db.SaveChanges();


            return editData;
        }

        public OurCompanyInfo DeleteObj(int id)
        {
            var deleteData = _db.OurCompanyInfo.Find(id);
            _db.Remove(deleteData);
            _db.SaveChanges();
            return deleteData;
        }
    }
}
