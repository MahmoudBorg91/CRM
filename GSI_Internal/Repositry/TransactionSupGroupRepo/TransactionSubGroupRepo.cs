using GSI_Internal.Context;
using GSI_Internal.Entites;
using System.Collections.Generic;
using System.Linq;
namespace GSI_Internal.Repositry.TransactionSupGroupRepo
{
    public class TransactionSubGroupRepo : ITransactionSubGroupRepo
    {
        private readonly dbContainer db;
        public TransactionSubGroupRepo(dbContainer db)
        {
            this.db = db;
        }
        TransactionSubGroup ITransactionSubGroupRepo.AddObj(TransactionSubGroup obj)
        {
            var data = db.TransactionSubGroup.Add(obj);
            db.SaveChanges();
            return obj;
        }

        TransactionSubGroup ITransactionSubGroupRepo.DeleteObj(int id)
        {
            var DeleteObj = db.TransactionSubGroup.Find(id);
            db.Remove(DeleteObj);
            db.SaveChanges();
            return DeleteObj;

        }

        IEnumerable<TransactionSubGroup> ITransactionSubGroupRepo.GetAll()
        {
            var data = db.TransactionSubGroup.Select(a => a);
            return data;
        }

        TransactionSubGroup ITransactionSubGroupRepo.GetByID(int id)
        {
            var data = db.TransactionSubGroup.Find(id);
            return data;
        }

        TransactionSubGroup ITransactionSubGroupRepo.UpdateObj(TransactionSubGroup obj)
        {
            var oldData = db.TransactionSubGroup.Find(obj.ID);
            oldData.TransactionGroupID = obj.TransactionGroupID;
            oldData.SubGroupNameArabic = obj.SubGroupNameArabic;
            oldData.SubGroupNameEnglish = obj.SubGroupNameEnglish;
            db.SaveChanges();
            return oldData;
        }
    }
}
