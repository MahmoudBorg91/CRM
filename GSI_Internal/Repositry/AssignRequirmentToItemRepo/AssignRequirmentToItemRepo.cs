using GSI_Internal.Context;
using GSI_Internal.Entites;
using System.Collections.Generic;
using System.Linq;
namespace GSI_Internal.Repositry.AssignRequirmentToItemRepo
{
    public class AssignRequirmentToItemRepo : IAssignRequirmentToItemRepo
    {
        private readonly dbContainer db;

        public AssignRequirmentToItemRepo(dbContainer db)
        {
            this.db = db;
        }
        public AssignRequirmentToItem AddObj(AssignRequirmentToItem obj)
        {
            db.AssignRequirmentToItem.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public AssignRequirmentToItem DeleteObj(int id)
        {
            var deleteObj = db.AssignRequirmentToItem.Find(id);
            db.AssignRequirmentToItem.Remove(deleteObj);
            db.SaveChanges();
            return deleteObj;
        }

        public IEnumerable<AssignRequirmentToItem> GetAll()
        {
            var data = db.AssignRequirmentToItem.Select(a => a);
            return data;
        }

        public AssignRequirmentToItem GetById(int id)
        {
            var data = db.AssignRequirmentToItem.Find(id);
            return data;
        }

        public AssignRequirmentToItem UpdateObj(AssignRequirmentToItem obj)
        {
            var updateObj = db.AssignRequirmentToItem.Find(obj.ID);

            updateObj.RequirmentID = obj.RequirmentID;
            updateObj.TransactionItemID = obj.TransactionItemID;

            db.SaveChanges();
            return obj;
        }
    }
}
