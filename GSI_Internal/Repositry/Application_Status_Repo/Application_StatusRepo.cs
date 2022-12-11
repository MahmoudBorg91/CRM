using GSI_Internal.Context;
using GSI_Internal.Entites;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSI_Internal.Repositry.Application_Status_Repo
{
    public class Application_StatusRepo : IApplication_StatusRepo
    {
        private readonly dbContainer db;

        public Application_StatusRepo(dbContainer db)
        {
            this.db = db;
        }
      



        public  string GetStatusTransfer_Name(int StatusAction_Code)
        {
            var data = db.StatusTransfer_Name.Where(a => a.StatusAction_Code == StatusAction_Code).Select(a => a.StatusAction_Name).FirstOrDefault();
            return data;
        }
    }
}
