using GSI_Internal.Context;
using GSI_Internal.Entites;
using System.Collections.Generic;
using System.Linq;

namespace GSI_Internal.Repositry.RequirmentsFileAttachmentRepo
{
    public class RequirmentsFileAttachmentRepo : IRequirmentsFileAttachmentRepo
    {
        private readonly dbContainer db;

        public RequirmentsFileAttachmentRepo(dbContainer db)
        {
            this.db = db;
        }
        public RequirmentsFileAttachment AddObj(RequirmentsFileAttachment obj)
        {
            var data = db.RequirmentsFileAttachment.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public RequirmentsFileAttachment EditFile(RequirmentsFileAttachment obj)
        {
            var oldData = db.RequirmentsFileAttachment.Find(obj.Id);
            oldData.Id=obj.Id;
            oldData.FileName=obj.FileName;
            db.SaveChanges();
            return oldData;
        }

        public RequirmentsFileAttachment DeleteObj(int Id)
        {
            throw new System.NotImplementedException();
        }

        public RequirmentsFileAttachment EditObj(RequirmentsFileAttachment obj)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<RequirmentsFileAttachment> GetAll()
        {
            var data = db.RequirmentsFileAttachment.Select(a => a);
            return data;
        }

        public RequirmentsFileAttachment GetByID(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}
