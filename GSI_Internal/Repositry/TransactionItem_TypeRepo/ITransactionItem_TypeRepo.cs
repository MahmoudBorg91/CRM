using System.Collections.Generic;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.TransactionItem_TypeRepo
{
    public interface ITransactionItem_TypeRepo
    {
        IEnumerable<TransactionItem_Type> GetAll();
        TransactionItem_Type GetByID(int id);
        TransactionItem_Type AddObj(TransactionItem_Type obj);
        TransactionItem_Type UpdateObj(TransactionItem_Type obj);
        TransactionItem_Type DeleteObj(int id);
    }
}
