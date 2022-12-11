using GSI_Internal.Context;
using GSI_Internal.Entites;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GSI_Internal.Repositry.DashboardRepo
{
    public class DashboardRepo : IDashboardRepo
    {
        private readonly dbContainer db;

        public DashboardRepo(dbContainer db)
        {
            this.db = db;
        }

        public IEnumerable<ApplicationTransaction_Request> GetAllTransactioc()
        {
            var data = db.ApplicationTransaction_Request.Select(a => a).ToList();
            return data;
        }

        public IEnumerable<ApplicationTransaction_Request> GetAllTransactiocByStatus(int status)
        {
            var data = db.ApplicationTransaction_Request.Where(a => a.Status == status).Select(a => a).ToList();
            return data;
        }

        public ApplicationTransaction_Request GetByAPPCode(Guid AppCode)
        {
            var data = db.ApplicationTransaction_Request.Where(a => a.ID == AppCode).Select(a => a).FirstOrDefault();
            return data;
        }
    }
}
