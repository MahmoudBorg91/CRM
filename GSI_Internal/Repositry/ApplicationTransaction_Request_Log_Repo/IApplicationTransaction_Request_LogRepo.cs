
using GSI_Internal.Entites;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GSI_Internal.Repositry.ApplicationTransaction_Request_Log_Repo
{
    public interface IApplicationTransaction_Request_LogRepo
    {
        Task<ApplicationTransaction_Request_Log> AddObj(ApplicationTransaction_Request_Log obj);

        IEnumerable<ApplicationTransaction_Request_Log> GetByAppCode(Guid AppCode);


    }
}
