using System.Collections.Generic;
using System.Linq;
using GSI_Internal.Context;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.TransactionItem_TypeRepo
{
    public class TransactionItem_TypeRepo : ITransactionItem_TypeRepo
    {
        private readonly dbContainer _db;

        public TransactionItem_TypeRepo(dbContainer db)
        {
            _db = db;
        }
        public IEnumerable<TransactionItem_Type> GetAll()
        {
            var data = _db.TransactionItem_Type.Select(a => a);
            return data;
        }

        public TransactionItem_Type GetByID(int id)
        {
            var data = _db.TransactionItem_Type.Find(id);
            return data;
        }

        public TransactionItem_Type AddObj(TransactionItem_Type obj)
        {
            var data = _db.TransactionItem_Type.Add(obj);
            _db.SaveChanges();
            return obj;
        }

        public TransactionItem_Type UpdateObj(TransactionItem_Type obj)
        {
            var editdata = _db.TransactionItem_Type.Find(obj.ID);
            editdata.ID = obj.ID;
            editdata.NameArabic = obj.NameArabic;
            editdata.NameEnglish = obj.NameEnglish;
            if (obj.Icon != null)
            {
                editdata.Icon = obj.Icon;
            }
           
            _db.SaveChanges();
            return editdata;

        }

        public TransactionItem_Type DeleteObj(int id)
        {
            var DeleteData = _db.TransactionItem_Type.Find(id);
            _db.Remove(DeleteData);
            _db.SaveChanges();
            return DeleteData;
        }
    }
}
