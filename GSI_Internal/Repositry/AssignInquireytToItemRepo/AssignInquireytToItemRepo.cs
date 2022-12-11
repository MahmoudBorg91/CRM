using System.Collections.Generic;
using System.Linq;
using GSI_Internal.Context;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.AssignInquireytToItemRepo
{
    public class AssignInquireytToItemRepo:IAssignInquireytToItemRepo
    {
        private readonly dbContainer db;

        public AssignInquireytToItemRepo(dbContainer db)
        {
            this.db = db;
        }

        public IEnumerable<AssignInquiryToItem> GetAll()
        {
            var data = db.AssignInquiryToItem.Select(a => a);
            return data;
        }
    }
}
