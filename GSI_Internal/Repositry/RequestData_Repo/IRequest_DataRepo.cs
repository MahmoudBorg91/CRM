using System.Collections.Generic;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.RequestData_Repo
{
    public interface IRequest_DataRepo
    {
        IEnumerable<Requests_Data> GetAll();
        Requests_Data GetByID(int id);
        Requests_Data AddObj(Requests_Data obj);
        Requests_Data UpdateObj(Requests_Data obj);
        Requests_Data DeleteObj(int id);
    }
}
