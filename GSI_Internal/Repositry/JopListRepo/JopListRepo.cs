using System.Collections.Generic;
using System.Linq;
using GSI_Internal.Context;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.JopListRepo
{
    public class JopListRepo:IJopListRepocs
    {
        private readonly dbContainer _db;

        public JopListRepo(dbContainer db)
        {
            _db = db;
        }
        public IEnumerable<JopList> GetAll()
        {
            var data = _db.JopList.Select(a => a);
            return data;
        }

        public JopList GetByID(int id)
        {
            var data = _db.JopList.Find(id);
            return data;
        }

        public JopList AddObj(JopList obj)
        {
            var data = _db.JopList.Add(obj);
            _db.SaveChanges();
            return obj;
        }

        public JopList UpdateObj(JopList obj)
        {
            var data = _db.JopList.Find(obj.ID);
            data.ID=obj.ID;
            data.JopCode = obj.JopCode;
            data.JopNameArabic=obj.JopNameArabic;
            data.JopNameEnglish=obj.JopNameEnglish;
            data.SkilllevelArabic=obj.SkilllevelArabic;
            data.SkilllevelEnglish=obj.SkilllevelEnglish;
            data.occupationCode = obj.occupationCode;
            data.qualificationArabic=obj.qualificationArabic;
            data.qualificationEnglish=obj.qualificationEnglish;

            _db.SaveChanges();
            return data;
        }

        public JopList DeleteObj(int id)
        {
            var data = _db.JopList.Find(id);
            _db.JopList.Remove(data);
            return data;
        }
    }
}
