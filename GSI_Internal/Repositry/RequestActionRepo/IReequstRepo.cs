using System.Collections.Generic;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.RequestActionRepo
{
    public interface IReequstRepo
    {
        IEnumerable<RequestAction> GetAll();
        RequestAction GetByID(int id);
        RequestAction AddObj(RequestAction obj);
        RequestAction UpdatToAccept(RequestAction obj);
        RequestAction UpdatToReject(RequestAction obj);

    }
}
