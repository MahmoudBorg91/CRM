using GSI_Internal.Entites;
using System.Collections.Generic;
namespace GSI_Internal.Repositry.TransactionItemInquiryRepo
{
    public interface ITransactionItemInquiryReop
    {
        IEnumerable<TransactionItemInquiry> GetAll();
        TransactionItemInquiry GetByID(int id);
        TransactionItemInquiry AddObj(TransactionItemInquiry obj);
        TransactionItemInquiry UpdateObj(TransactionItemInquiry obj);
        TransactionItemInquiry DeleteObj(int id);
    }
}
