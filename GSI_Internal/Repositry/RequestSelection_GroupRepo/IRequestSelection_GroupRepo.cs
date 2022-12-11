using System.Collections.Generic;
using GSI_Internal.Entites;

namespace GSI_Internal.Repositry.RequestSelection_GroupRepo
{
    public interface IRequestSelection_GroupRepo
    {
        IEnumerable<RequestSelection_Group> GetAll();
        RequestSelection_Group GetByID(int id);
        RequestSelection_Group AddObj(RequestSelection_Group obj);
        RequestSelection_Group UpdateObj(RequestSelection_Group obj);
        RequestSelection_Group DeleteObj(int id);
    }

}
