using System;
using GSI_Internal.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GSI_Internal.Repositry.ApplicationTransaction_RequestRepo
{
    public interface IApplicationTransaction_RequestRepo
    {
        ApplicationTransaction_Request GetByID(int id);

        ApplicationTransaction_Request AddObj(ApplicationTransaction_Request obj);
        ApplicationTransaction_Request EditObj(ApplicationTransaction_Request obj);


        Task<ApplicationTransaction_Request> UpdateObjToSubmation(ApplicationTransaction_Request obj);
        Task<ApplicationTransaction_Request> UpdateObjToPayment(ApplicationTransaction_Request obj);
        Task<ApplicationTransaction_Request> UpdateObjToPaymentDone(ApplicationTransaction_Request obj);
        Task<ApplicationTransaction_Request> UpdateStatusUnderProcessing(ApplicationTransaction_Request obj);
        Task<ApplicationTransaction_Request> UpdateStatusToDone(ApplicationTransaction_Request obj);
        Task<ApplicationTransaction_Request> UpdateStatusToMissingInformation(ApplicationTransaction_Request obj);
        Task<ApplicationTransaction_Request> UpdateStatusToMissingProcessing(ApplicationTransaction_Request obj);
        Task<ApplicationTransaction_Request> UpdateStatusRejectFromUS(ApplicationTransaction_Request obj);
        Task<ApplicationTransaction_Request> UpdateStatusRejectFromEntity(ApplicationTransaction_Request obj);
        Task<ApplicationTransaction_Request> UpdateStatusToTransfer(ApplicationTransaction_Request obj);
        Task<ApplicationTransaction_Request> UpdateApplicationToNewProcess(ApplicationTransaction_Request obj);
        //Task<ApplicationTransaction_Request> UpdateApplicationToCProcess(ApplicationTransaction_Request obj);


        Task<ApplicationTransaction_Request_Processing> UpdateRequestToProcess(ApplicationTransaction_Request_Processing obj);
        //Task<ApplicationTransaction_Request_Processing> UpdateRequestToTakeAction(ApplicationTransaction_Request_Processing obj);

        //Task<ApplicationTransaction_Request> UpdateApplictionToProcessing(ApplicationTransaction_Request obj);



        IEnumerable<ApplicationTransaction_Request> GetAll();
        ApplicationTransaction_Request_Processing GetAllProcessingByAppId(Guid AppID);
        IEnumerable<ApplicationTransaction_Request_Processing> GetAllProcessing();
    }
}
