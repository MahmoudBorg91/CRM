using GSI_Internal.Entites;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace GSI_Internal.Repositry.Application_Status_Repo
{
    public interface IApplication_StatusRepo
    {
      
        


        string GetStatusTransfer_Name(int StatusAction_Code);

    }
}
