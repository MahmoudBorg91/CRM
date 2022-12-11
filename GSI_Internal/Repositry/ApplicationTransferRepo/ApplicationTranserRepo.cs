using GSI_Internal.Context;
using GSI_Internal.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSI_Internal.Repositry.ApplicationTransferRepo
{
    public class ApplicationTranserRepo : IAppliactionTransferRepo
    {
        private readonly dbContainer db;

        public ApplicationTranserRepo(dbContainer db)
        {
            this.db = db;
        }
        public async Task<ApplicationTransfer> AddObj(ApplicationTransfer obj)
        {
            db.ApplicationTransfer.Add(obj);
            await db.SaveChangesAsync();
           return obj;
        }

        public IEnumerable<ApplicationTransfer> GetByAppCode(Guid AppCode)
        {
            var Data = db.ApplicationTransfer.Where(a => a.App_Code == AppCode).Select(a => a).ToList();
            return Data;
        }

      
    }
}
