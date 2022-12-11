using System.Collections.Generic;
using System.Linq;
using GSI_Internal.Context;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.AssignSelectionToItem_Repo
{
    public class AssignSelectionToItemRepo : IAssignSelectionToItemRepo
    {
        private readonly dbContainer db;

        public AssignSelectionToItemRepo(dbContainer db)
        {
            this.db = db;
        }
        public IEnumerable<AssignSelectionToItem> GetAll()
        {
            var data = db.AssignSelectionToItem.Select(a => a);
            return data;
        }
    }
}
