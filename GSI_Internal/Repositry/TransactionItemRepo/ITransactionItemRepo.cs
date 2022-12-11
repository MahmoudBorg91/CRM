using GSI_Internal.Entites;
using System.Collections.Generic;
namespace GSI_Internal.Repositry.TransactionItemRepo
{
    public interface ITransactionItemRepo
    {
        IEnumerable<TransactionItem> GetAll();
        TransactionItem GetByID(int id);
        TransactionItem AddObj(TransactionItem obj);
        TransactionItem UpdateObj(TransactionItem obj);
        TransactionItem DeleteObj(int id);

    }
}
