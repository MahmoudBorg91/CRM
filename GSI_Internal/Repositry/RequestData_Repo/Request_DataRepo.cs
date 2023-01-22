using System.Collections.Generic;
using System.Linq;
using GSI_Internal.Context;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.RequestData_Repo
{
    public class Request_DataRepo:IRequest_DataRepo
    {
        private readonly dbContainer _db;

        public Request_DataRepo(dbContainer db)
        {
            _db = db;
        }
        public IEnumerable<Requests_Data> GetAll()
        {
            var data = _db.Requests_Data.Select(a => a);
            return data;
        }

        public Requests_Data GetByID(int id)
        {
            var data = _db.Requests_Data.Find(id);
            return data;
        }

        public Requests_Data AddObj(Requests_Data obj)
        {
            _db.Requests_Data.Add(obj);
            _db.SaveChanges();
            return obj;
        }

        public Requests_Data UpdateObj(Requests_Data obj)
        {
            var updateDate = _db.Requests_Data.Find(obj.ID);
            updateDate.ID=obj.ID;
            updateDate.RequestName= obj.RequestName;
            _db.SaveChanges();
            return obj;
        }

        public Requests_Data DeleteObj(int id)
        {
            var data = _db.Requests_Data.Find(id);
            _db.Requests_Data.Remove(data);
            _db.SaveChanges();
            return data;
        }
    }
}
