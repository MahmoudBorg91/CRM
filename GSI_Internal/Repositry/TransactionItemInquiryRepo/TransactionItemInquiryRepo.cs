
using System.Collections.Generic;
using System.Linq;
using GSI_Internal.Context;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.TransactionItemInquiryRepo
{
    public class TransactionItemInquiryRepo: ITransactionItemInquiryReop
    {
        private readonly dbContainer db;

        public TransactionItemInquiryRepo(dbContainer db)
        {
            this.db = db;
        }
        public IEnumerable<TransactionItemInquiry> GetAll()
        {
            var data = db.TransactionItemInquiry.Select(a => a).ToList();
            return data;
        }

        public TransactionItemInquiry GetByID(int id)
        {
            var data = db.TransactionItemInquiry.Find(id);
            return data;
        }

        public TransactionItemInquiry AddObj(TransactionItemInquiry obj)
        {
            var data= db.TransactionItemInquiry.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public TransactionItemInquiry UpdateObj(TransactionItemInquiry obj)
        {
            var oldObj = db.TransactionItemInquiry.Find(obj.ID);
            oldObj.InquiryName_Arabic=obj.InquiryName_Arabic;
            oldObj.InquiryName_English=obj.InquiryName_English;
            oldObj.Inquiry_Type=obj.Inquiry_Type;
            db.SaveChanges();
            return oldObj;
        }

        public TransactionItemInquiry DeleteObj(int id)
        {
           var deleteobj=db.TransactionItemInquiry.Find(id);
           db.TransactionItemInquiry.Remove(deleteobj);
           db.SaveChanges();
           return deleteobj;
        }
    }
}
