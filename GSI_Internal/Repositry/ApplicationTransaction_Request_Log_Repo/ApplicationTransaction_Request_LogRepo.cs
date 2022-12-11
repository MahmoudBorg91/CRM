using GSI_Internal.Context;
using GSI_Internal.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace GSI_Internal.Repositry.ApplicationTransaction_Request_Log_Repo
{
    public class ApplicationTransaction_Request_LogRepo : IApplicationTransaction_Request_LogRepo
    {
        private readonly dbContainer db;

        public ApplicationTransaction_Request_LogRepo(dbContainer db)
        {
            this.db = db;
        }
        public async Task<ApplicationTransaction_Request_Log> AddObj(ApplicationTransaction_Request_Log obj)
        {
            db.ApplicationTransaction_Request_Log.Add(obj);
            await db.SaveChangesAsync();
            return obj;
        }

        public IEnumerable<ApplicationTransaction_Request_Log> GetByAppCode(Guid AppCode)
        {
            var Data = db.ApplicationTransaction_Request_Log.Where(a => a.App_Code == AppCode).Select(a => a).ToList();
            return Data;
        }
    }
}
