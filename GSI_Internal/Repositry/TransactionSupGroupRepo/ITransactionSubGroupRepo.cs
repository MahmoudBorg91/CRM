using GSI_Internal.Entites;
using System.Collections.Generic;
namespace GSI_Internal.Repositry.TransactionSupGroupRepo
{
    public interface ITransactionSubGroupRepo
    {
        IEnumerable<TransactionSubGroup> GetAll();
        TransactionSubGroup GetByID(int id);
        TransactionSubGroup AddObj(TransactionSubGroup obj);
        TransactionSubGroup UpdateObj(TransactionSubGroup obj);
        TransactionSubGroup DeleteObj(int id);

    }
}
