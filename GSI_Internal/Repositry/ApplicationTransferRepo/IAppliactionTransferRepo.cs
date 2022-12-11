using GSI_Internal.Entites;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace GSI_Internal.Repositry.ApplicationTransferRepo
{
    public interface IAppliactionTransferRepo
    {
         Task<ApplicationTransfer> AddObj(ApplicationTransfer obj);

        IEnumerable<ApplicationTransfer> GetByAppCode(Guid AppCode);


        //   IEnumerable<ApplicationTransfer> UpdateTranfestSataus();
    }
}
