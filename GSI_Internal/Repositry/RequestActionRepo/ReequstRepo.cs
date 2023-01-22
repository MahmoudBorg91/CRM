using System.Collections.Generic;
using System.Linq;
using GSI_Internal.Context;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.RequestActionRepo
{
    public class ReequstRepo:IReequstRepo
    {
        private readonly dbContainer _db;

        public ReequstRepo(dbContainer db)
        {
            _db = db;
        }
        public IEnumerable<RequestAction> GetAll()
        {
            var data = _db.RequestAction.Select(a => a);
            return data;
        }

        public RequestAction GetByID(int id)
        {
            var data = _db.RequestAction.Find(id);
            return data;
        }

        public RequestAction AddObj(RequestAction obj)
        {
           _db.RequestAction.Add(obj);
           _db.SaveChanges();
           return obj;
        }

        public RequestAction UpdatToAccept(RequestAction obj)
        {
            var UpdateData = _db.RequestAction.Find(obj.ID);

            UpdateData.status = 1;
            UpdateData.NoteStatus = obj.NoteStatus;
            UpdateData.UserTakeAction=obj.UserTakeAction;
            _db.SaveChanges();
            return obj;
        }

        public RequestAction UpdatToReject(RequestAction obj)
        {
            var UpdateData = _db.RequestAction.Find(obj.ID);
            UpdateData.status = 2;
            UpdateData.NoteStatus = obj.NoteStatus;
            UpdateData.UserTakeAction = obj.UserTakeAction;
            _db.SaveChanges();
            return obj;
        }
    }
}
