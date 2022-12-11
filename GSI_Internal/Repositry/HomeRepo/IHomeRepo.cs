using GSI_Internal.Entites;
using System.Collections.Generic;

namespace GSI_Internal.Repositry.HomeRepo
{
    public interface IHomeRepo
    {
        IEnumerable<TransactionGroup> GetAllTransactionGroup();
        IEnumerable<TransactionItem> GetAllTransactionItem();
        IEnumerable<TransactionItem> GetAllTransactionsByGroup(int id);
        IEnumerable<TransactionSubGroup> GetAllTransactionSubGroups();
        IEnumerable<TransactionSubGroup> GetAllSubGroupByGroup(int id);
        //  IEnumerable<TransactionSubGroup> GetAllSubGroupByGroup(int id);

    }
}
