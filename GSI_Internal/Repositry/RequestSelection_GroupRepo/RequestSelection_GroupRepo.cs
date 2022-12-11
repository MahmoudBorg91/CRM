using System.Collections.Generic;
using System.Linq;
using GSI_Internal.Context;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.RequestSelection_GroupRepo
{
    public class RequestSelection_GroupRepo: IRequestSelection_GroupRepo
    {
        private readonly dbContainer db;
        public RequestSelection_GroupRepo(dbContainer db)
        {
            this.db = db;
        }

        public IEnumerable<RequestSelection_Group> GetAll()
        {
            var data = db.RequestSelection_Group.Select(a => a);
            return data;
        }

        public RequestSelection_Group GetByID(int id)
        {
            var data = db.RequestSelection_Group.Find(id);
            return data;
        }

        public RequestSelection_Group AddObj(RequestSelection_Group obj)
        {
           var data = db.RequestSelection_Group.Add(obj);
           db.SaveChanges();
           return obj;
        }

        public RequestSelection_Group UpdateObj(RequestSelection_Group obj)
        {
            var EditData = db.RequestSelection_Group.Find(obj.ID);
            EditData.Selection_GroupName_Arab = obj.Selection_GroupName_Arab;
            EditData.Selection_GroupName_English=obj.Selection_GroupName_English;
            db.SaveChanges();
            return EditData;
        }

        public RequestSelection_Group DeleteObj(int id)
        {
            var DeleteData = db.RequestSelection_Group.Find(id);
            db.Remove(DeleteData);
            db.SaveChanges();
            return DeleteData;
        }
    }
}
