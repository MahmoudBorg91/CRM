using System.Collections.Generic;
using System.Linq;
using GSI_Internal.Context;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.SlideShowRepo
{
    public class SlideShowRepo : ISlideShowRepo
    {
        private readonly dbContainer _db;

        public SlideShowRepo(dbContainer db)
        {
            _db = db;
        }
        public IEnumerable<SlideShow> GetAll()
        {
            var data = _db.SlideShow.Select(a => a);
            return data;
        }

        public SlideShow GetByID(int id)
        {
            var data = _db.SlideShow.Find(id);
            return data;
        }

        public SlideShow AddObj(SlideShow obj)
        {
          var data = _db.SlideShow.Add(obj);
          _db.SaveChanges();
          return obj;
        }

        public SlideShow UpdateObj(SlideShow obj)
        {
            var oldData = _db.SlideShow.Find(obj.ID);
            oldData.ID=obj.ID;
            oldData.ReSizeme_Arabic=obj.ReSizeme_Arabic;
            oldData.ReSizeme_English=obj.ReSizeme_English;
            oldData.Title_Arabic = obj.Title_English;
            oldData.Title_English=obj.Title_English;
            if (obj.SlideImage != null)
            {
                oldData.SlideImage = obj.SlideImage;
            }
            oldData.ShowInMobile = obj.ShowInMobile;
            oldData.ShowInWeb = obj.ShowInWeb;
            _db.SaveChanges();
            return oldData;

        }

        public SlideShow DeleteObj(int id)
        {
           var deleteData= _db.SlideShow.Find(id);
           _db.SlideShow.Remove(deleteData);
           _db.SaveChanges();
           return deleteData;

        }
    }
}
