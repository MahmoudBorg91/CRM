using System.Collections.Generic;
using System.Linq;
using GSI_Internal.Context;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.RequestSelection_SelectedRepo
{
    public class RequestSelection_Selectes: IRequestSelection_Selectes
    {
        private readonly dbContainer db;

        public RequestSelection_Selectes(dbContainer db)
        {
            this.db = db;

        }
        public IEnumerable<RequestSelection> GetAll()
        {
            var data = db.RequestSelection.Select(a => a);
            return data;
        }
    }
}
