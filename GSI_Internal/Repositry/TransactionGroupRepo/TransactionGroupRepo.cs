using GSI_Internal.Context;
using GSI_Internal.Entites;
using System.Collections.Generic;
using System.Linq;

namespace GSI_Internal.Repositry.TransactionGroupRepo
{
    public class TransactionGroupRepo : ITransactionGroupRepo
    {
        private readonly dbContainer db;

        public TransactionGroupRepo(dbContainer db)
        {
            this.db = db;
        }
        public TransactionGroup AddObj(TransactionGroup obj)
        {
            var data = db.transactionGroup.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public TransactionGroup DeleteObj(int id)
        {
            var deleteObj = db.transactionGroup.Find(id);
            db.Remove(deleteObj);
            db.SaveChanges();
            return deleteObj;


        }

        public IEnumerable<TransactionGroup> GetAll()
        {
            var data = db.transactionGroup.Select(a => a);
            return data;
        }

        public TransactionGroup GetById(int id)
        {
            var data = db.transactionGroup.Find(id);
            return data;
        }

        public string GetNameById(int id)
        {
            var name = db.transactionGroup.Where(a => a.ID == id).Select(a => a.TransactionGroup_NameArabic).FirstOrDefault().ToString();
            return name;
        }
        public string GetNameEnglishById(int id)
        {
            var name = db.transactionGroup.Where(a => a.ID == id).Select(a => a.TransactionGroup_NameEnglish).FirstOrDefault().ToString();
            return name;
        }

        public TransactionGroup UpdateObj(TransactionGroup obj)
        {
            var Editobj = db.transactionGroup.Find(obj.ID);
            Editobj.TransactionGroup_NameArabic = obj.TransactionGroup_NameArabic;
            Editobj.TransactionGroup_NameEnglish = obj.TransactionGroup_NameEnglish;
            Editobj.IsNotAvailbale = obj.IsNotAvailbale;
            if (obj.logo != null)
            {
                Editobj.logo = obj.logo;
            }
            if (obj.Icon != null)
            {
                Editobj.Icon = obj.Icon;
            }
            db.SaveChanges();
            return obj;
        }
    }
}
