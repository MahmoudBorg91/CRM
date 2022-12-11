using GSI_Internal.Entites;
using System;
using System.Collections.Generic;

namespace GSI_Internal.Repositry.DashboardRepo
{
    public interface IDashboardRepo
    {

        IEnumerable<ApplicationTransaction_Request> GetAllTransactioc();
        IEnumerable<ApplicationTransaction_Request> GetAllTransactiocByStatus(int status);
        ApplicationTransaction_Request GetByAPPCode(Guid AppCode);

    }
}
