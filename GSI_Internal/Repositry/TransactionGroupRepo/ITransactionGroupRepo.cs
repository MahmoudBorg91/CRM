using GSI_Internal.Entites;
using System.Collections.Generic;

namespace GSI_Internal.Repositry.TransactionGroupRepo

{
    public interface ITransactionGroupRepo
    {
        IEnumerable<TransactionGroup> GetAll();
        TransactionGroup GetById(int id);
        TransactionGroup AddObj(TransactionGroup obj);
        TransactionGroup UpdateObj(TransactionGroup obj);
        TransactionGroup DeleteObj(int id);
        string GetNameById(int id);
        string GetNameEnglishById(int id);







    }
}
