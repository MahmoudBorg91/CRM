using GSI_Internal.Context;
using GSI_Internal.Entites;
using System.Collections.Generic;
using System.Linq;

namespace GSI_Internal.Repositry.TransactionItemRepo
{
    public class TransactionItemRepo : ITransactionItemRepo
    {
        private readonly dbContainer db;

        public TransactionItemRepo(dbContainer db)
        {
            this.db = db;
        }
        public TransactionItem AddObj(TransactionItem obj)
        {
            var data = db.transactionItem.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public TransactionItem DeleteObj(int id)
        {
            var DeleteObj = db.transactionItem.Find(id);
            db.Remove(DeleteObj);
            db.SaveChanges();
            return DeleteObj;
        }

        public IEnumerable<TransactionItem> GetAll()
        {
            var data = db.transactionItem.Select(a => a);
            return data;
        }

        public TransactionItem GetByID(int id)
        {
            var data = db.transactionItem.Find(id);
            return data;

        }

        public TransactionItem UpdateObj(TransactionItem obj)
        {
            var EditObj = db.transactionItem.Find(obj.ID);
            EditObj.TransactionNameArabic = obj.TransactionNameArabic;
            EditObj.TransactionNameEnglish = obj.TransactionNameEnglish;
            EditObj.TransactionGroupID = obj.TransactionGroupID;
            EditObj.TransactionSubGroupID = obj.TransactionSubGroupID;
            EditObj.Price = obj.Price;
            EditObj.GovernmentFees = obj.GovernmentFees;
            EditObj.Services_Conditions_Arabic=obj.Services_Conditions_Arabic;
            EditObj.Services_Conditions_English=obj.Services_Conditions_English;
            EditObj.ServicesDecription_Arabic = obj.ServicesDecription_Arabic; 
            EditObj.ServicesDecription_English =obj.ServicesDecription_English;
            EditObj.Time_Services_Arabic=obj.Time_Services_Arabic;
            EditObj.Time_Services_English=obj.Time_Services_English;
            EditObj.SetInMostServices = obj.SetInMostServices;
            EditObj.SetInMostServices_INSubGroup=obj.SetInMostServices_INSubGroup;
            EditObj.IsNotAvailbale=obj.IsNotAvailbale;
            if (obj.ServicesPhoto != null)
            {
                EditObj.ServicesPhoto = obj.ServicesPhoto;
            }
            if (obj.Icon != null)
            {
                EditObj.Icon = obj.Icon;
            }
            db.SaveChanges();
            return EditObj;

        }
    }
}
