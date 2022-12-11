using GSI_Internal.Context;
using GSI_Internal.Entites;
using System.Collections.Generic;
using System.Linq;

namespace GSI_Internal.Repositry.HomeRepo
{
    public class HomeRepo : IHomeRepo
    {
        private readonly dbContainer db;

        public HomeRepo(dbContainer db)
        {
            this.db = db;
        }

        public IEnumerable<TransactionSubGroup> GetAllSubGroupByGroup(int id)
        {
            var data = db.TransactionSubGroup.Where(a => a.TransactionGroupID == id).Select(a => a);
            return data;
        }

        public IEnumerable<TransactionGroup> GetAllTransactionGroup()
        {
            var data = db.transactionGroup.Select(a => a);
            return data;
        }

        public IEnumerable<TransactionItem> GetAllTransactionItem()
        {
            var data = db.transactionItem.Select(a => a);
            return data;
        }

        public IEnumerable<TransactionItem> GetAllTransactionsByGroup(int id)
        {
            var data = db.transactionItem.Where(a => a.TransactionSubGroupID == id).Select(a => a);
            return data;
        }

        public IEnumerable<TransactionSubGroup> GetAllTransactionSubGroups()
        {
            var data = db.TransactionSubGroup.Select(a => a);
            return data;
        }
    }
}
